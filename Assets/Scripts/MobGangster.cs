using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGangster : EnemyMelee
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
        yield return new WaitForSeconds(meleeAttackSpeed * 0.5f);
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit with a club!");
        yield return new WaitForSeconds(meleeAttackSpeed * 0.5f);
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }
}
