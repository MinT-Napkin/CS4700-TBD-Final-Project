using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumEnforcer : EnemyMelee
{

    protected override void Start(){
        base.Start();
    }
    
    public override void MeleeAttack()
    {
        bool isAttacking = true;

        /*
        For animations:
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        The slum enforcer doesn't move that fast but attacks quickly - the opposite of the mob gangster. Has higher chase range than the mob gangster.
        Balacning: Adjust entityStats later
        */
        animator.SetBool("isAttacking", isAttacking);
        base.MeleeAttack();
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
    }

    public void MeleeAttackEvent()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.SEMeleeSound);
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            DamageTypeLightning damageType = new DamageTypeLightning();
            DamageEvent damageEvent = new DamageEvent(1.5f, damageType, this, targetHit.gameObject.GetComponent<Entity>(), DamageCategory.Normal);
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
}
