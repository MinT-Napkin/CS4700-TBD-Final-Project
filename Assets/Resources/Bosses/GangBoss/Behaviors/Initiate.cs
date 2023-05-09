using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiate : StateMachineBehaviour
{    
    public GangBoss boss;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       boss = animator.gameObject.GetComponent<GangBoss>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss.distance <= boss.initiateRange)
        {
            animator.SetTrigger("MoveDown");
            boss.healthbar.gameObject.SetActive(true);
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        MusicPlayer.PlayClip(1);
        animator.ResetTrigger("MoveDown");
        boss.bossObstacle.GetComponent<BossObstacle>().spawnBossObstacle();
    }
}
