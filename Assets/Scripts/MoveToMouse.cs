using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToMouse : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float sampleDistance = 0.5f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Animator")]
    [SerializeField] private Animator animator;
    [SerializeField] private string upperBodyLayerName = "UpperBody";

    private NavMeshAgent agent;
    private int upperBodyLayerIndex = -1;
    private bool isPunchingPlaying;

    #region << Animator Paramaters >>
    private static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    private static readonly int IsWalkingHash = Animator.StringToHash("isWalking");
    private static readonly int PunchingHash = Animator.StringToHash("Punching");
    #endregion

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        if (animator != null)
            upperBodyLayerIndex = animator.GetLayerIndex(upperBodyLayerName);
    }

    private void Update()
    {
        MoveToMouseHandler();
        UpdateLocomotion();
        UpdateUpperBody();
    }

    private void MoveToMouseHandler()
    {
        // Left mouse button to move
        if (!Input.GetMouseButton(0))
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundLayer)) 
        {
            if (NavMesh.SamplePosition(hit.point, out NavMeshHit navHit, sampleDistance, NavMesh.AllAreas))
                agent.SetDestination(navHit.position);
        }
    }


    private void UpdateLocomotion()
    {
        // Update animator parameters based on agent velocity
        if (animator == null) return;

        float speed = agent.velocity.magnitude;

        // isWalking Parameter
        bool isWalking = speed > 0.1f;
        animator.SetBool(IsWalkingHash, isWalking);

        // MoveSpeed Parameter
        float normalized = Mathf.InverseLerp(0f, agent.speed, speed);
        animator.SetFloat(MoveSpeedHash, normalized);
    }

    private void UpdateUpperBody()
    {
        if (animator == null || upperBodyLayerIndex < 0)
            return;

        // Right click to initiate a punch
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetLayerWeight(upperBodyLayerIndex, 1f);
            animator.SetTrigger(PunchingHash);
            isPunchingPlaying = true;
        }

        // To avoid cutting off the punch animation, we check if it's still playing
        if (isPunchingPlaying)
        {
            AnimatorStateInfo st = animator.GetCurrentAnimatorStateInfo(upperBodyLayerIndex);

            bool inPunchState = st.IsName("Punch");

            if (inPunchState && st.normalizedTime >= 1f)
            {
                isPunchingPlaying = false;
                animator.SetLayerWeight(upperBodyLayerIndex, 0f);
            }
            else
            {
                animator.SetLayerWeight(upperBodyLayerIndex, 1f);
            }
        }
        else
        {
            // keep it disabled when not punching
            animator.SetLayerWeight(upperBodyLayerIndex, 0f);
        }
    }
}
