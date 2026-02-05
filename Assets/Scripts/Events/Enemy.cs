using System;
using UnityEngine;

namespace Events
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public int health = 10;

        private void OnEnable()
        {
            EventsManager.Instance.BulletHitSomethingAction += EnemyHit;
            EventsManager.Instance.DeathAction += DeathHandler;
        }

        private void OnDisable()
        {
            EventsManager.Instance.BulletHitSomethingAction -= EnemyHit;
            EventsManager.Instance.DeathAction -= DeathHandler;
        }

        private void EnemyHit(Collider other)
        {
            if (other == null) return;
            if (other.gameObject == gameObject)
            {
                Debug.Log("C# Action and UnityEvent: Enemy got hit!");
            }
        }

        public void DamageHandlerBonus(BulletEnteredEventArgs bulletArgs)
        {
            int previousHealth = health;
            if (bulletArgs.Target == null || !bulletArgs.Target.gameObject == gameObject) return;

            health -= bulletArgs.DamageDealt;
            Debug.Log($"Bonus class: Health {previousHealth} - {bulletArgs.DamageDealt} = {health}");


            if (health <= 0)
            {
                EventsManager.Instance.OnDeath();
            }
        }

        private void DeathHandler()
        {
            Debug.Log("C# Action: Enemy is dead!");
            Destroy(gameObject);
        }
    }
}