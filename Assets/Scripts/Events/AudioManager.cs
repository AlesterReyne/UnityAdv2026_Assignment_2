using UnityEngine;

namespace Events
{
    public class AudioManager : MonoBehaviour
    {
        private void Start()
        {
            EventsManager.BulletFiredAction += PlayFireSound;
        }

        private void PlayFireSound()
        {
            Debug.unityLogger.Log("BOOOM!");
        }
    }
}
