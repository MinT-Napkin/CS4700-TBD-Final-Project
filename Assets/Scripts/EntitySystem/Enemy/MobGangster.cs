using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGangster : EnemyMelee{
    protected override void Start(){
        base.Start();
    }
    public override void MeleeAttack(){
        SoundManager.instance.PlaySound(SoundManager.instance.MGMeleeSound);
        bool isAttacking = true;
        /*
        For animations:
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        The mob gangster runs up to the player fast but its attack has a long wind up and recovery time. Has a relatively low chase range.
        Balancing: adjust entityStats later
        */
        animator.SetBool("isAttacking", isAttacking);
        base.MeleeAttack();
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
    }

    public void MeleeAttackEvent()
    {
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            DamageTypePhysical damageType = new DamageTypePhysical();
            DamageEvent damageEvent = new DamageEvent(1f, damageType, this, targetHit.gameObject.GetComponent<Entity>(), DamageCategory.Normal);
            targetHit.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
        }
        bool isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }

    public void OnMeleeAttackEndEvent()
    {
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}


