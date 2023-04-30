using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumEnforcer : EnemyMelee
{
    public override void MeleeAttack()
    {
        /*
        For animations:
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        The cyborg gangster doesn't move that fast but attacks quickly - the opposite of the mob gangster
        Balacning: Adjust entityStats later
        */
        base.MeleeAttack();
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit by SlumEnforcer!");
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }
}
