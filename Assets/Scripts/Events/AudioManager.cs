using UnityEngine;

namespace Events
{
    public class AudioManager : MonoBehaviour
    {
        EventsManager eventsManager;

        private void Start()
        {
            EventsManager.Instance.BulletFiredAction += PlayFireSound;
        }

        public void PlayFireSound()
        {
            Debug.unityLogger.Log("C# Action and UnityEvent: BOOOM!");
        }
    }
}