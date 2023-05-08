using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAIBoss : Boss
{
    public int phase = 1;
    public float attackCooldown;
    public bool attackOnCooldown = false;
    public override void Awake()
    {
        base.Awake();
        //Test entity stats
        entityStats.walkSpeed = 2f;
        entityStats.currentHealth = 50f;
        entityStats.maxHealth = 50f;
        entityStats.normalizedHealth = 1f;
    }

    public override void Update()
    {
        base.Update();
        if ((entityStats.normalizedHealth <= 0.5f) && (phase < 2))
        {
            animator.SetTrigger("PhaseTransition");
            phase = 2;
            //Boost entityStats
        }
    }

    public override void RotateEvent()
    {
        base.RotateEvent();
        attackPoint.localPosition = new Vector2(-0.0900000036f,-0.0430000015f);
    }

    public override void SetAttackPointDownEvent()
    {
        attackPoint.localPosition = new Vector2(0.00100000005f,-0.129999995f);
    }

    public override void SetAttackPointUpEvent()
    {
        attackPoint.localPosition = new Vector2(0f,0.116999999f);
    }

    public override void MeleeAttackEvent()
    {
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            //Apply damage
            Debug.Log(targetHit.gameObject.name + " phase 1 hit!");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, initiateRange);

        Gizmos.color = new Color(141/255f, 13/255f, 225/255f);
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }

    public void AttackCooldown()
    {
        StartCoroutine(AttackCooldownCoroutine());
    }

    IEnumerator AttackCooldownCoroutine()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }
}
