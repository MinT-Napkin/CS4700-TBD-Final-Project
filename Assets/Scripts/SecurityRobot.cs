using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityRobot : EnemyMelee
{
    public override void MeleeAttack()
    {
        /*
        For animations:
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        Security robot is an upgraded version of the slum enforcer. Moves slightly faster and has a slightly higher chase range. Its attacks apply stun.
        Balacning: Adjust entityStats later
        */
        base.MeleeAttack();
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit by SecurityRobot!");
            //Apply Stun
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }
}
