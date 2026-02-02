using System;
using UnityEngine;
using UnityEngine.Events;

namespace Events
{
    public class EventsManager : MonoBehaviour
    {
        /* Assignment was to do collision or trigger mechanic without references, only events.
         We needed to do the only code solution with 3 C# actions and 2 UnityEvents.
         2 events/actions we need to be done with sending parameters.
         I did 3:
         1) C# Action with 1 parameter
         2) C# Action with 2 parameters
         3) UnityEvent with 1 parameter. */

        // Singleton
        public static EventsManager Instance;

        // 3 Actions, only code, 2 with parameters
        public event Action BulletFiredAction;
        public event Action<Collider> BulletHitSomethingAction;
        public event Action<Collider, int> BulletDamagedAction;


        private void Awake()
        {
            if (Instance != this && Instance == null)
                Instance = this;
        }

        // Invoke functions for only the code solution
        public void OnBulletFired()
        {
            BulletFiredAction?.Invoke();
        }

        public void OnBulletHitSomething(Collider other)
        {
            BulletHitSomethingAction?.Invoke(other);
        }

        public void OnBulletDamaged(Collider other, int damage)
        {
            BulletDamagedAction?.Invoke(other, damage);
        }
    }
}