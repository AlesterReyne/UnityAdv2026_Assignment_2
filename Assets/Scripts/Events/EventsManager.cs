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
         I did 3 (third from bonus):
         1) C# Action with 1 parameter
         2) UnityEvent with 2 parameters.
         3) UnityEvent with struct for a parameter */

        // Singleton
        public static EventsManager Instance;

        // 3 Actions, only code, 2 with parameters
        public event Action BulletFiredAction;
        public event Action DeathAction;
        public event Action<Collider> BulletHitSomethingAction;

        // Unity Event with struct and Action bonus
        [SerializeField] private UnityEvent<BulletEnteredEventArgs> onBonusUnityEvent;
        public UnityAction<BulletEnteredEventArgs> onBonusUnityAction;

        private void Awake()
        {
            if (Instance != this && Instance == null)
                Instance = this;
        }

        private void Start()
        {
            onBonusUnityAction = OnBonusUnityEvent;
        }

        // Invoke functions for only the code solution
        public void OnBulletFired()
        {
            BulletFiredAction?.Invoke();
        }

        public void OnDeath()
        {
            DeathAction?.Invoke();
        }

        public void OnBulletHitSomething(Collider other)
        {
            BulletHitSomethingAction?.Invoke(other);
        }

        private void OnBonusUnityEvent(BulletEnteredEventArgs args)
        {
            onBonusUnityEvent?.Invoke(args);
        }
    }
}