using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemy
{
   public float rangedAttackAndDetectionRange;
   public float rangedAttackSpeed;
   public bool rangedAttackOnCooldown;

    public override void Update()
    {
        base.Update();
        if (distance <= chaseRange)
        {
            RotateEnemy();
            aiPath.canMove = true;
            if (distance <= rangedAttackAndDetectionRange)
            {
                aiPath.canMove = false;
                if (!rangedAttackOnCooldown)
                    RangedAttack();
            }
        }
        else
        {
            aiPath.canMove = false;
        }
    }

    public virtual void RangedAttack()
    {
        StartCoroutine(RangedAttackCooldown());
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
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangedAttackAndDetectionRange);
    }
}
