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

    private static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    private static readonly int IsWalkingHash = Animator.StringToHash("isWalking");
    private static readonly int PunchingHash = Animator.StringToHash("Punching");

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
        if (animator == null) return;

        float speed = agent.velocity.magnitude;

        // Bool for transitions
        bool isWalking = speed > 0.1f;
        animator.SetBool(IsWalkingHash, isWalking);

        // Float for blend tree
        float normalized = Mathf.InverseLerp(0f, agent.speed, speed);
        animator.SetFloat(MoveSpeedHash, normalized);
    }

    private void UpdateUpperBody()
    {
        if (animator == null || upperBodyLayerIndex < 0)
            return;

        bool holdingRightClick = Input.GetMouseButton(1);

        animator.SetLayerWeight(upperBodyLayerIndex, holdingRightClick ? 1f : 0f);

        if (Input.GetMouseButtonDown(1))
            animator.SetTrigger(PunchingHash);
    }
}
