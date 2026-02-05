using UnityEngine;

public class AnimatorDriver : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Update()
    {
        float move = Mathf.Abs(Input.GetAxis("Vertical"));

        animator.SetFloat("MoveSpeed", move);
        animator.SetFloat("AnimSpeed", Mathf.Lerp(0.7f, 1.3f, move));
        animator.SetBool("IsMoving", move > 0.1f);

        // Upper body layer weight
        float upperWeight = Input.GetMouseButton(1) ? 1f : 0f;
        animator.SetLayerWeight(1, upperWeight);
    }
}
