using UnityEngine;

namespace Events
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}