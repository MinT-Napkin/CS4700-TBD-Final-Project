using System.Collections;
using System.Collections.Generic;
//using UnityEngine.UI;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour{
    public Transform attackPoint;
    public float attackDamage = 10;
    public float attackRange = 0.5f;
    public float attackCooldown = 1;
    bool attackOnCooldown = false;
    public string description;
    public LayerMask enemyLayers;
    new public string name;
    public EntityStats playerStats;

    public virtual void Awake(){
        enemyLayers = LayerMask.GetMask("Enemy");
        //playerStats = attackPoint.parent.gameObject.GetComponent<PlayerClass>().playerStats;
    }

    void Update(){
        if (Input.GetKeyDown("x")){
            if (!attackOnCooldown){
                Attack();
            }
        }
    }

    public void SetEntityStats(EntityStats playerStats){
        this.playerStats = playerStats;
    }

    void Attack(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies){
            StartCoroutine(AttackCooldown());
            StartCoroutine(DebugEnemyHitColor(enemy)); //Debug - to check if enemy is hit
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackCooldown(){
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }

    IEnumerator DebugEnemyHitColor(Collider2D enemy){
        enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
