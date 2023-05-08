using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAndRanged : Enemy
{
    public float meleeAttackRange;
    public float meleeDetectionRange;
    public float meleeAttackCooldown;
    public float rangedAttackCooldown;
    public float rangedAttackRange;
    public bool meleeAttackOnCooldown = false;
    public bool rangedAttackOnCooldown = false;

    public override void Awake()
    {
        base.Awake();
        aiPath.endReachedDistance = meleeAttackRange;
    }

    public override void Update()
    {
        base.Update();
        if (distance <= chaseRange)
        {
            aiPath.canMove = true;
            RotateEnemy();
            if (distance <= meleeDetectionRange)
            {
                if (!meleeAttackOnCooldown)
                    MeleeAttack();
            }
        }
        else
        {
            aiPath.canMove = false;
        }

        if ((distance <= rangedAttackRange) && (distance >= chaseRange))
        {
            RotateEnemy();
            if (!rangedAttackOnCooldown)
                RangedAttack();
        }
    }

    public virtual void MeleeAttack()
    {
        StartCoroutine(MeleeAttackCooldown());
    }

    public virtual void RangedAttack()
    {
        StartCoroutine(RangedAttackCooldown());
    }

    IEnumerator MeleeAttackCooldown()
    {
        meleeAttackOnCooldown = true;
        yield return new WaitForSeconds(meleeAttackCooldown);
        meleeAttackOnCooldown = false;
    }

    IEnumerator RangedAttackCooldown()
    {
        rangedAttackOnCooldown = true;
        yield return new WaitForSeconds(rangedAttackCooldown);
        rangedAttackOnCooldown = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeDetectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangedAttackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
