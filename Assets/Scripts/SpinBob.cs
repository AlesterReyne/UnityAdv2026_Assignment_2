using UnityEngine;

public class SpinBob : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 90f;
    [SerializeField] private float bobHeight = 0.25f;
    [SerializeField] private float bobSpeed = 2f;

    private Vector3 startPos;

    private void Awake()
    {
        startPos = transform.localPosition;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime, Space.Self);

        float y = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        transform.localPosition = startPos + new Vector3(0f, y, 0f);
    }
}