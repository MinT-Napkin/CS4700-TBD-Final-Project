using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemy
{
   public float rangedAttackRange;
   public float rangedAttackSpeed;
   public float fleeRange;
   public float fleeSpeedMultiplier;
   public bool rangedAttackOnCooldown;

    Rigidbody2D rb2d;
   float savedWalkSpeed;

    public override void Awake()
    {
        base.Awake();
        savedWalkSpeed = entityStats.walkSpeed;
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
    }

    public override void Update()
    {
        base.Update();
        if ((distance <= chaseRange) && (distance >= rangedAttackRange))
        {
            RotateEnemy();
            aiPath.canMove = true;
        }
        else
        {
            aiPath.canMove = false;
        }

        if (distance <= rangedAttackRange)
        {
            RotateEnemy();
            entityStats.walkSpeed = 0f;
            if (distance <= fleeRange)
                rb2d.velocity = -(direction) * fleeSpeedMultiplier;
            if (!rangedAttackOnCooldown)
                RangedAttack();
        }
        else
        {
            entityStats.walkSpeed = savedWalkSpeed;
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
        Gizmos.DrawWireSphere(transform.position, rangedAttackRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fleeRange);
    }
}
