using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : Enemy
{
   public float rangedAttackAndDetectionRange;
   public float rangedAttackSpeed;
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
        if ((distance <= chaseRange) && (distance >= rangedAttackAndDetectionRange))
        {
            RotateEnemy();
            aiPath.canMove = true;
        }
        else
        {
            aiPath.canMove = false;
        }

        if (distance <= rangedAttackAndDetectionRange)
        {
            RotateEnemy();
            entityStats.walkSpeed = 0f;
            if (distance <= rangedAttackAndDetectionRange - 1)
                rb2d.velocity = -(direction) * 1.7f;
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
        Gizmos.DrawWireSphere(transform.position, rangedAttackAndDetectionRange);
    }
}
