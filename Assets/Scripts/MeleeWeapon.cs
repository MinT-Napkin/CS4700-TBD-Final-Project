using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour{
    public Transform attackPoint;
    public float attackDamage = 10;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public EntityStats playerStats;
    public float attackCooldown = 1f;
    bool attackOnCooldown = false;

    public virtual void Awake(){
        enemyLayers = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            if (!attackOnCooldown)
                Attack();
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            StartCoroutine(AttackCooldown());
            StartCoroutine(DebugEnemyHitColor(enemy)); //Debug - to check if enemy is hit
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }

    IEnumerator DebugEnemyHitColor(Collider2D enemy)
    {
        enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
