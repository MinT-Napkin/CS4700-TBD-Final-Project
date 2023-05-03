using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour{
    public Transform attackPoint;
    public float attackDamage;
    public float attackCooldown;
    public bool attackOnCooldown = false;
    protected DamageTypeParent damageType;
    public string description;
    public LayerMask enemyLayers;
    new public string name;
    public string inputKey;
    public bool input;
    public EntityStats playerStats;
    public int upgradeLevel;

    public virtual void Awake(){
        enemyLayers = LayerMask.GetMask("Enemy");
        attackPoint = gameObject.GetComponent<PlayerClass>().rangedAttackPoint;
        playerStats = gameObject.GetComponent<PlayerClass>().entityStats;
    }

    public virtual void Update(){
        if (input){
            if (!attackOnCooldown){
                Attack();
            }
        }
    }

    public virtual void Upgrade(){
    }

    public virtual void Attack(){
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown(){
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }   
}
