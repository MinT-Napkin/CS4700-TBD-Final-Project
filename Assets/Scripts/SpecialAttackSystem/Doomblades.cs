using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doomblades : SpecialAttack{
    public float doombladesRange;
    Animator animator;

    public override void Awake(){
        base.Awake();
        animator = gameObject.GetComponent<Animator>();
        name = "Doomblades";
        damageType = new DamageTypePhysical();
        description = "A set of four giant blades designed with brutal slaughter in mind. Removed from the arm of an old military AI prototype robot.";
        attackDamage = 2.0f;
        attackCooldown = 5.0f;
        doombladesRange = 2f;
        attackPoint = gameObject.GetComponent<PlayerClass>().meleeAttackPoint;
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;

        //Adjust damage and cooldown based on upgrade level here
    }

    public override void Upgrade(){
        upgradeLevel += 1;
        attackCooldown -= 0.5f;
    }

    public override void Attack(){
        SoundManager.instance.PlaySound(SoundManager.instance.doomBladesSound);
        StartCoroutine(Activate());
        base.Attack();
    }

    IEnumerator Activate(){
        DamageEvent damageEvent;
        bool enemyKilled = false;

        animator.SetBool("Doomblades", true);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, doombladesRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies){
            damageEvent = new DamageEvent(attackDamage, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Entity>(), DamageCategory.Special);

            enemy.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
            //Check if an enemy was killed here
            if (enemy.gameObject.GetComponent<Entity>().entityStats.normalizedHealth <= 0)
                enemyKilled = true;
        }
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Doomblades", false);
        if (upgradeLevel > 1){
            if (enemyKilled){
                yield return new WaitForSeconds(0.5f); //for color debugging
                if (upgradeLevel > 2) { attackDamage *= 1.1f; }
                StartCoroutine(Activate());
            }
        }
    }
}
