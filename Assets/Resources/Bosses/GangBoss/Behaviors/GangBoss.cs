using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangBoss : Boss
{
    public GameObject bulletPrefab;
    public BossBullet bulletData;
    public float bulletSpeed;

    public override void Awake()
    {
        //Add more here
        base.Awake();
        //Stats for testing
        entityStats.walkSpeed = 2f;
        entityStats.maxHealth = 100f;
        entityStats.currentHealth = 100f;
        entityStats.normalizedHealth = 1f;
        bulletData = bulletPrefab.GetComponent<BossBullet>();
        bulletData.boss = this as Boss;
        bulletData.bulletRange = rangedAttackRange;
        bulletData.bulletSpeed = this.bulletSpeed;
    }

    protected override void OnEntityDeath()
    {
        base.OnEntityDeath();
    }

    public override void RotateEvent()
    {
        base.RotateEvent();
        attackPoint.localPosition = new Vector2(-0.082f, -0.039f);
    }

    public override void SetAttackPointDownEvent()
    {
        attackPoint.localPosition = new Vector2(0.021f, -0.167f);
    }

    public override void SetAttackPointUpEvent()
    {
        attackPoint.localPosition = new Vector2(0.013f, 0.079f);
    }

    public override void MeleeAttackEvent()
    {
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            Debug.Log("target hit");
            //new DamageEvent()
            //DamageEvent.ApplyDamage()
            //targetHit.gameObject.GetComponent<Entity>().TakeDamage()
        }
    }

    public override void RangedAttackEvent()
    {
        Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation);
        StartCoroutine(RangedAttackCooldown());
    }

    IEnumerator RangedAttackCooldown()
    {
        rangedAttackOnCooldown = true;
        yield return new WaitForSeconds(rangedAttackCooldown);
        rangedAttackOnCooldown = false;
    }
}
