using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : StateMachineBehaviour
{
    public OldAIBoss2 boss;
    float distanceDashing;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss = animator.gameObject.GetComponent<OldAIBoss2>();
       boss.dashCollisionEnabled = true;
       boss.rb2d.velocity = boss.direction * boss.dashSpeed;
       distanceDashing = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       distanceDashing += Time.deltaTime * boss.dashSpeed;
       if (distanceDashing >= boss.maxDashDistance)
       {
            animator.SetTrigger("EndDash");
            boss.rb2d.velocity = Vector3.zero;
       }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Dash");
       boss.dashCollisionEnabled = false;
    }
}
