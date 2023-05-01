using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGangster : EnemyMelee
{
    public override void MeleeAttack()
    {
        /*
        For animations:
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        The mob gangster runs up to the player fast but its attack has a long wind up and recovery time. Has a relatively low chase range.
        Balancing: adjust entityStats later
        */
        base.MeleeAttack();
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit by MobGangster!");
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }
}
