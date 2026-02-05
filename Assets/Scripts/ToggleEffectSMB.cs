using UnityEngine;

public class ToggleEffectSMB : StateMachineBehaviour
{
    public string effectObjectName = "PunchVFX";

    private GameObject fx;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fx == null)
        {
            Transform t = animator.transform.Find(effectObjectName);

            if (t == null)
            {
                foreach (Transform child in animator.GetComponentsInChildren<Transform>(true))
                {
                    if (child.name == effectObjectName)
                    {
                        t = child;
                        break;
                    }
                }
            }

            fx = t != null ? t.gameObject : null;
        }

        if (fx != null)
            fx.SetActive(true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fx != null)
            fx.SetActive(false);
    }
}
