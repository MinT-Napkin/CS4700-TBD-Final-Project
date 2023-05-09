using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Executioner : MeleeWeapon{
    public override void Awake(){
        base.Awake();
        attackDamage = 10.0f;
        attackRange = 1.0f;
        damageType = new DamageTypePhysical();
        description = "The guilty cannot escape judgement";
        name = "Executioner";
    }

    protected override void Attack(){
        SoundManager.instance.PlaySound(SoundManager.instance.meleeSound);
        DamageEvent damageEvent;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies){
            if (enemy.gameObject.GetComponent<Enemy>().entityStats.normalizedHealth > 0.5f) {
                damageEvent = new DamageEvent(1.0f, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Enemy>(), DamageCategory.Normal);
            }
            else{
                damageEvent = new DamageEvent((1.0f + (0.5f - (enemy.gameObject.GetComponent<Enemy>().entityStats.normalizedHealth / 2))), damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Enemy>(), DamageCategory.Normal);
            }

            enemy.gameObject.GetComponent<Enemy>().TakeDamage(damageEvent);
        }

        StartCoroutine(AttackCooldown());
    }

    public override void Equip(){
        base.Equip();
    }
    public override void Unequip(){
        base.Unequip();
    }
}
