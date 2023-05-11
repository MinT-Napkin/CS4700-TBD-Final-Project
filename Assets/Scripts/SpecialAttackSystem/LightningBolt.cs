using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : SpecialAttack
{
    public float lightningBoltRange;
    public Vector2 directon;
    Animator animator;
    public override void Awake()
    {
        base.Awake();
        name = "Lightning Bolt";
        description = "Lightning bolt created by a traditional, military-grade weapon. This technology is used in many kinds of weaponry.";
        attackDamage = 5f;
        attackCooldown = 5f;
        lightningBoltRange = 10f;
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;
        attackPoint = gameObject.GetComponent<PlayerClass>().lightningBoltAttackPoint;
        animator = attackPoint.gameObject.GetComponent<Animator>();
        //Adjust damage and cooldown based on upgrade level here
    }

    public override void Upgrade()
    {
        upgradeLevel += 1;
    }

    public override void Attack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.lightningBoltSound);
        StartCoroutine(Activate());
        base.Attack();
    }

    IEnumerator Activate()
    {
        for (int i = 0; i < upgradeLevel; i++)
        {
            animator.SetTrigger("LightningBolt");
            animator.ResetTrigger("EndLightningBolt");
    
            RaycastHit2D[] hitEnemies1 = new List<RaycastHit2D>().ToArray();
            RaycastHit2D[] hitEnemies2 = new List<RaycastHit2D>().ToArray();
            hitEnemies1 = Physics2D.RaycastAll(attackPoint.position, -attackPoint.right, lightningBoltRange / 2, enemyLayers);
            hitEnemies2 = Physics2D.RaycastAll(attackPoint.position, attackPoint.right, lightningBoltRange / 2, enemyLayers);
            foreach (RaycastHit2D enemy in hitEnemies1)
            {
                DamageTypeParent damageType = new DamageTypeLightning();
                DamageEvent damageEvent = new DamageEvent(attackDamage * 0.2f, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.collider.gameObject.GetComponent<Entity>(), DamageCategory.Special);
                enemy.collider.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
                if (upgradeLevel > 2)
                {
                //apply stun
                }
            }
            foreach (RaycastHit2D enemy in hitEnemies2)
            {
                DamageTypeParent damageType = new DamageTypeLightning();
                DamageEvent damageEvent = new DamageEvent(attackDamage * 0.2f, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.collider.gameObject.GetComponent<Entity>(), DamageCategory.Special);
                enemy.collider.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
                if (upgradeLevel > 2)
                {
                //apply stun
                }
            }

            yield return new WaitForSeconds(0.5f);
            animator.SetTrigger("EndLightningBolt");
            animator.ResetTrigger("LightningBolt");

            yield return new WaitForSeconds(0.5f);
        }
    }
}
