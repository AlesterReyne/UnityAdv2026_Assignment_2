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
            EventsManager.Instance.BulletDamagedAction += DamageHandler;
        }

        private void OnDisable()
        {
            EventsManager.Instance.BulletHitSomethingAction -= EnemyHit;
            EventsManager.Instance.BulletDamagedAction -= DamageHandler;
        }

        public void EnemyHit(Collider other)
        {
            if (other == null) return;
            if (other.gameObject == gameObject)
            {
                Debug.Log("C# Action and UnityEvent: Enemy got hit!");
            }
        }

        private void DamageHandler(Collider other, int damage)
        {
            int previousHealth = health;
            if (other == null) return;
            if (other.gameObject == gameObject)
            {
                health -= damage;
                Debug.Log($"C# Action: Health {previousHealth} - {damage} = {health}");
            }

            if (health <= 0)
            {
                Debug.Log("C# Action: Enemy is dead!");
                Destroy(gameObject);
            }
        }
    }
}