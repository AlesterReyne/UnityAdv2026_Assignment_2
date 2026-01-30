using System;
using UnityEngine;

namespace Events
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] public int health = 10;
        private void OnEnable()
        {
            EventsManager.BulletHitSomethingAction += EnemyHit;
            EventsManager.BulletDamagedAction += DamageHandler;
        }

        private void OnDisable()
        {
            EventsManager.BulletHitSomethingAction -= EnemyHit;
        }

        private void EnemyHit(Collider other)
        {
            if (other == null) return;
            if (other.gameObject == gameObject)
            {
                Debug.Log("Enemy got hit!");
            }
        }

        private void DamageHandler(Collider other, int damage)
        {
            if (other == null) return;
            if (other.gameObject == gameObject)
            { 
                health -= damage;
            }

            if (health <= 0)
            {
                Debug.Log("Enemy is dead!");
                Destroy(gameObject);
            }
        }
    }
}
