using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] protected string pickUpName = "Pick Up";

    protected virtual void OnPickUp(GameObject picker)
    {
        Debug.Log($"picker.name picked up {pickUpName}");
        Destroy(picker);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnPickUp(other.gameObject);
    }
    
    
}
