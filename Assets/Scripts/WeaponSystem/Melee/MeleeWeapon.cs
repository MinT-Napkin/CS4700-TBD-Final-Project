using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour{
    public Transform attackPoint;
    public float attackDamage = 10.0f;
    public float attackRange = 0.5f;
    public float attackCooldown = 1.0f;
    public bool attackOnCooldown = false;
    protected DamageTypeParent damageType;
    public string description;
    public LayerMask enemyLayers;
    new public string name;
    public EntityStats playerStats;
    public string inputKey;

    public virtual void Awake(){
        enemyLayers = LayerMask.GetMask("Enemy");
        //playerStats = attackPoint.parent.gameObject.GetComponent<PlayerClass>().playerStats;
        inputKey = "x";
    }

    public virtual void Equip(){
        playerStats.attackSpeed *= attackCooldown;
        playerStats.strength += attackDamage;
    }

    public virtual void Unequip(){
        playerStats.attackSpeed /= attackCooldown;
        playerStats.strength -= attackDamage;
    }

    public void SetEntityStats(EntityStats playerStats){
        this.playerStats = playerStats;
    }

    public virtual void Attack(){
        SoundManager.instance.PlaySound(SoundManager.instance.meleeSound);
        DamageEvent damageEvent;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies){
            damageEvent = new DamageEvent(1.0f, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Enemy>(), DamageCategory.Normal);
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(damageEvent);
        }
        StartCoroutine(AttackCooldown());
    }

    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    protected IEnumerator AttackCooldown(){
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }
}
