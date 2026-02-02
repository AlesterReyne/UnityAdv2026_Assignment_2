using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class Bullet : MonoBehaviour
    {
        // 2 Unity Event, inspector, 1 with parameter
        [SerializeField] public UnityEvent onBulletFiredUnityEvent;
        [SerializeField] public UnityEvent<Collider> onBulletEnteredUnityEvent;

        [SerializeField] private float bulletSpeed = 1;
        [SerializeField] private int damage = 1;

        public void Start()
        {
            EventsManager.Instance.OnBulletFired();
            // Invoke for UnityEvents solution
            onBulletFiredUnityEvent?.Invoke();
            transform.position += transform.forward * 1f;
        }

        void FixedUpdate()
        {
            transform.position += transform.forward * (bulletSpeed * Time.deltaTime);
        }

        public void OnTriggerEnter(Collider other)
        {
            EventsManager.Instance.OnBulletHitSomething(other);
            EventsManager.Instance.OnBulletDamaged(other, damage);
            // Invoke for UnityEvents solution
            onBulletEnteredUnityEvent?.Invoke(other);
            Destroy(gameObject);
        }
    }
}