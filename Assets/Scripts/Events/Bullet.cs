using System;
using Events.Bonus;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class Bullet : MonoBehaviour
    {
        // 2 Unity Event, inspector, 1 with parameter
        [SerializeField] public UnityEvent onBulletFiredUnityEvent;

        [SerializeField] private BulletSO bulletSO;
        [SerializeField] private float bulletSpeed = 1;


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
            BulletEnteredEventArgs args = new BulletEnteredEventArgs
            {
                DamageDealt = bulletSO.GetRandomDamage(),
                Target = other.GetComponent<Enemy>()
            };
            EventsManager.Instance.OnBulletHitSomething(other);
            EventsManager.Instance.onBonusUnityAction?.Invoke(args);
            Destroy(gameObject);
        }
    }

    public struct BulletEnteredEventArgs
    {
        public int DamageDealt;
        public Enemy Target;
    }
}