using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : Enemy{
    public float meleeAttackRange;
    public float meleeDetectionRange;
    public float meleeAttackCooldown;
    public bool meleeAttackOnCooldown = false;

    public override void Awake(){
        base.Awake();
        aiPath.endReachedDistance = meleeAttackRange;
        DamageTypeHealing damageType = new DamageTypeHealing();
        DamageEvent damageEvent = new DamageEvent(-100.0f, damageType, this, this, false);
    }

    protected override void Start(){
        base.Start();
    }

    public override void Update(){
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

    public virtual void MeleeAttack(){
        StartCoroutine(MeleeAttackCooldown());
    }

    IEnumerator MeleeAttackCooldown(){
        meleeAttackOnCooldown = true;
        yield return new WaitForSeconds(meleeAttackCooldown);
        meleeAttackOnCooldown = false;
    }

    public void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeDetectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
