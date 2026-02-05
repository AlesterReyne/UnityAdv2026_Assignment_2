using UnityEngine;

namespace Events.Bonus
{
    [CreateAssetMenu(fileName = "BulletSO", menuName = "Scriptable Objects/BulletSO")]
    public class BulletSO : ScriptableObject
    {
        [SerializeField] private int minimumDamage;
        [SerializeField] private int maximumDamage;

        public int GetRandomDamage()
        {
            int randomDamage = Random.Range(minimumDamage, maximumDamage + 1);
            Debug.Log("SO: Bullet damage is " + randomDamage);
            return randomDamage;
        }
    }
}