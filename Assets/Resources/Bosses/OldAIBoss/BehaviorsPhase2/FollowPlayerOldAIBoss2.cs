using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerOldAIBoss2 : StateMachineBehaviour
{
    public OldAIBoss2 boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss = animator.gameObject.GetComponent<OldAIBoss2>();
       animator.ResetTrigger("EndDash");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector2.Distance(boss.attackPoint.position, boss.target.position) <= boss.meleeAttackRange * 1.1f)
        {
            if (!boss.attackOnCooldown)
            {
                switch ((int)Random.Range(0, 2))
                {
                    case 0:
                        animator.SetTrigger("SingleAttack");
                        break;
                    case 1:
                        animator.SetTrigger("Combo");
                        break;
                }
            }
            boss.AttackCooldown();
        }

        Vector2 newPosition = Vector2.MoveTowards(boss.rb2d.position, boss.target.position, boss.entityStats.walkSpeed * Time.fixedDeltaTime);
        boss.rb2d.MovePosition(newPosition);
        if (boss.direction.y < -0.5f)
        {
            animator.SetTrigger("MoveDown");
        }
        else if (boss.direction.y >= 0.5f)
        {
            animator.SetTrigger("MoveUp");
        }
        else if (boss.direction.x < -0.5)
        {
            animator.SetTrigger("MoveLeftRight"); 
        }
        else if (boss.direction.x >= 0.5)
        {
            animator.SetTrigger("MoveLeftRight"); 
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("MoveDown");
       animator.ResetTrigger("MoveUp");
       animator.ResetTrigger("MoveLeftRight");
    }
}
