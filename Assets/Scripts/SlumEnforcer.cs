using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumEnforcer : EnemyMelee
{
    public override void MeleeAttack()
    {
        base.MeleeAttack();
        StartCoroutine(ExecuteMeleeAttack());
    }

    IEnumerator ExecuteMeleeAttack()
    {
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
        yield return new WaitForSeconds(meleeAttackSpeed);
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit by SlumEnforcer!");
        yield return new WaitForSeconds(0.5f);
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }
}
