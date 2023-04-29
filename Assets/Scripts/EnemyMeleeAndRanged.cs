using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAndRanged : Enemy
{
    public float meleeAttackRange;
    public float meleeDetectionRange;
    public float meleeAttackSpeed;
    public float rangedAttackSpeed;
    public float rangedAttackAndDetectionRange;
    public bool meleeAttackOnCooldown = false;
    public bool rangedAttackOnCooldown = false;

    public override void Awake()
    {
        base.Awake();
        aiPath.endReachedDistance = meleeAttackRange + 0.5f;
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

        if ((distance <= rangedAttackAndDetectionRange) && (distance >= chaseRange))
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
        yield return new WaitForSeconds(meleeAttackSpeed);
        meleeAttackOnCooldown = false;
    }

    IEnumerator RangedAttackCooldown()
    {
        rangedAttackOnCooldown = true;
        yield return new WaitForSeconds(rangedAttackSpeed);
        rangedAttackOnCooldown = false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeDetectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangedAttackAndDetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
