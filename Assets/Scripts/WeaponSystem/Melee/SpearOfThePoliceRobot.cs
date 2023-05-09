using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearOfThePoliceRobot : MeleeWeapon{
    public override void Awake(){
        base.Awake();
        attackDamage = 15.0f;
        attackRange = 1.5f;
        damageType = new DamageTypePhysical();
        description = "Stop Resisting";
        name = "Police Robot's Spear";
    }

    public override void Attack(){
        SoundManager.instance.PlaySound(SoundManager.instance.meleeSound);
        DamageEvent damageEvent;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies) {
            damageEvent = new DamageEvent(0.5f, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Enemy>(), DamageCategory.Normal);

            enemy.gameObject.GetComponent<Enemy>().TakeDamage(damageEvent);

            damageType = new DamageTypeLightning();

            damageEvent = new DamageEvent(0.5f, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Enemy>(), DamageCategory.Normal);

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

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
