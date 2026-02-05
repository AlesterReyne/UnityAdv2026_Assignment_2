using UnityEngine;

public class SpeedPickup_Variant : PickUp
{
    [SerializeField] private float speedBoost = 2f;
    [SerializeField] private float duration = 5f;

    protected override void OnPickUp(GameObject picker)
    {
        Debug.Log($"{picker.name} got speed boost x{speedBoost} for {duration} seconds");
        Destroy(gameObject);
    }
}