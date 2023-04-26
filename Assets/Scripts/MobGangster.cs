using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGangster : Enemy
{
    public override void MeleeAttack()
    {
        base.MeleeAttack();
        StartCoroutine(TestMelee());
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }

    IEnumerator TestMelee()
    {
        float saveWalkSpeed = entityStats.walkSpeed;
        entityStats.walkSpeed = 0f;
        freezeRotation = true;
        yield return new WaitForSeconds(1f);
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit with a club!");
        yield return new WaitForSeconds(1f);
        entityStats.walkSpeed = saveWalkSpeed;
        freezeRotation = false;
    }
}
