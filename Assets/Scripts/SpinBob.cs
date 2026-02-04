using UnityEngine;

public class SpinBob : MonoBehaviour
{
    [Serialized] private float spinSpeed = 90f;
    [Serialized] private float bobHeight = 0.25f;
    [Serialized] private float bobSpeed = 2f;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.self);
        
    private float y = Math.Sin(Time.time * bobSpeed) * bobHeight;
     
    transform.localPosition = startPos + new Vector3(0, y, 0);
    }

}


    