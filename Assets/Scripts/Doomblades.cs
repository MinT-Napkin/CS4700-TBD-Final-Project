using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doomblades : SpecialAttack{
    public float doombladesRange;

    public override void Awake(){
        base.Awake();
        name = "Doomblades";
        damageType = new DamageTypePhysical();
        description = "A set of four giant blades designed with brutal slaughter in mind. Removed from the arm of an old military AI prototype robot.";
        attackDamage = 5.0f;
        attackCooldown = 5.0f;
        doombladesRange = 2.5f;
        attackPoint = gameObject.GetComponent<PlayerClass>().meleeAttackPoint;
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;

        //Adjust damage and cooldown based on upgrade level here
    }

    public override void Upgrade(){
        upgradeLevel += 1;
        Debug.Log("Doomblades upgrade level: " + upgradeLevel);
    }

    public override void Attack(){
        StartCoroutine(Activate());
        base.Attack();
    }

    IEnumerator Activate(){
        DamageEvent damageEvent;
        bool enemyKilled = false;
        yield return new WaitForSeconds(0.8f);
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, doombladesRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies){
            damageEvent = new DamageEvent(attackDamage, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Enemy>(), DamageCategory.Special);

            enemy.gameObject.GetComponent<Enemy>().TakeDamage(damageEvent);
            //Check if an enemy was killed here
            enemyKilled = true; //for debugging
        }

        if (upgradeLevel > 1){
            if (enemyKilled){
                yield return new WaitForSeconds(0.5f); //for color debugging
                if (upgradeLevel > 2) { attackDamage *= 1.4f; }
                StartCoroutine(Activate());
            }
        }
    }
}
