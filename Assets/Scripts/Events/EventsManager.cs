using System;
using UnityEngine;

namespace Events
{
    public class EventsManager : MonoBehaviour
    {
        
        // 3 Actions
        public static event Action BulletFiredAction;
        public static event Action<Collider> BulletHitSomethingAction;
        public static event Action<Collider, int> BulletDamagedAction;
        
        // 2 Unity Event

        public static void OnBulletFired()
        {
            BulletFiredAction?.Invoke();
        }

        public static void OnBulletHitSomething(Collider other)
        {
            BulletHitSomethingAction?.Invoke(other);
        }

        public static void OnBulletDamaged(Collider other, int damage)
        {
            BulletDamagedAction?.Invoke(other, damage);
        }

    }
}
