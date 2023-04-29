using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy
{
    public float meleeAttackRange;
    public float meleeDetectionRange;
    public float meleeAttackSpeed;
    public bool meleeAttackOnCooldown = false;

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
    }

    public virtual void MeleeAttack()
    {
        StartCoroutine(MeleeAttackCooldown());
    }

    IEnumerator MeleeAttackCooldown()
    {
        meleeAttackOnCooldown = true;
        yield return new WaitForSeconds(meleeAttackSpeed);
        meleeAttackOnCooldown = false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeDetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
