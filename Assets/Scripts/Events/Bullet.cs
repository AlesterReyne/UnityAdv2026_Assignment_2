using System;
using UnityEngine;

namespace Events
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed = 1;
        [SerializeField] private int damage = 1;

        private void Start()
        {
            EventsManager.OnBulletFired();
            transform.position += transform.forward * 1f;
        }

        void Update()
        {
            transform.position += transform.forward * (bulletSpeed * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            EventsManager.OnBulletHitSomething(other);
            EventsManager.OnBulletDamaged(other, damage);
            Destroy(gameObject);
        }
    }
}
