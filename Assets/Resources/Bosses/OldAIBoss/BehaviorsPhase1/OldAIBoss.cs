using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAIBoss : Boss
{
    public GameObject bossObstacle;
    public GameObject phase2Prefab;
    EntityStats phase2Stats;
    public float attackCooldown;
    public bool attackOnCooldown = false;
    // public override void Awake()
    // {
    //     base.Awake();
    //     //Test entity stats
    //     entityStats.walkSpeed = 2.5f;
    //     entityStats.currentHealth = 80f;
    //     entityStats.maxHealth = 80f;
    //     entityStats.normalizedHealth = 1f;
    //     entityStats.strength = 3f;
    //     entityStats.criticalDamage = 1.1f;
    //     entityStats.criticalHitRate = 5;
    //     entityStats.level = 0;
    //     entityStats.defense = 10f;
    //     entityStats.specialDefense = 20f;
    // }

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
        SoundManager.instance.PlaySound(SoundManager.instance.oldAIBossMeleeSound);
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            DamageTypeParent damageType = new DamageTypePhysical();
            DamageEvent damageEvent = new DamageEvent(entityStats.strength * 0.2f, damageType, this, targetHit.gameObject.GetComponent<Entity>(), DamageCategory.Normal);
            targetHit.GetComponent<Entity>().TakeDamage(damageEvent);
        }
    }

    protected override void OnEntityDeath()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.oldAIBossDeathSound);
        base.OnEntityDeath();
        MusicPlayer.PlayClip(3);
    }

    public override void AfterDeathAnimation()
    {
        Instantiate(phase2Prefab, transform.position, transform.rotation);
        Destroy(gameObject);
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
