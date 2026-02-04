using UnityEngine;

public class HealthPickup_Variant : PickUp
{
    [SerializeField] private int healAmount = 25;

    protected override void OnPickUp(GameObject picker)
    {
        Debug.Log($"{picker.name} healed for {healAmount}");
        Destroy(gameObject);
    }
}