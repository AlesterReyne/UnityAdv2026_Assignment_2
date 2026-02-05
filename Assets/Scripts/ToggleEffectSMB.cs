using UnityEngine;

public class ToggleEffectSMB : StateMachineBehaviour
{
    [Tooltip("Child object name under the Animator root (or its children).")]
    public string effectObjectName = "PunchVFX";

    private GameObject fx;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fx == null)
        {
            Transform t = animator.transform.Find(effectObjectName);

            // If not found as direct child, search deeper
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

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fx != null)
            fx.SetActive(false);
    }
}
