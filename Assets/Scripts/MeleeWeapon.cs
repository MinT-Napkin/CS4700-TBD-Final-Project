using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour{
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public EntityStats playerStats;
    public MeleeWeaponData equippedMeleeWeapon;
    public List<MeleeWeaponData> meleeWeaponList;
    bool attackOnCooldown = false;

    void Awake(){
        enemyLayers = LayerMask.GetMask("Enemy");
    }

    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            if (!attackOnCooldown)
                Attack();
        }
        if (Input.GetKeyDown("k"))
        {
            MeleeWeaponData toEquip = meleeWeaponList.ToArray()[1];
            if (toEquip.inInventory)
                equippedMeleeWeapon = toEquip;
        }
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, equippedMeleeWeapon.attackRange, enemyLayers);
        StartCoroutine(AttackCooldown());
        foreach (Collider2D enemy in hitEnemies)
        {
            SpecialAbility(enemy);
            StartCoroutine(DebugEnemyHitColor(enemy)); //Debug - to check if enemy is hit
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, equippedMeleeWeapon.attackRange);
    }

    void SpecialAbility(Collider2D enemy)
    {
        switch (equippedMeleeWeapon.name)
        {
            case "Modified Outsider's Blade":
                Debug.Log("3x damage from criticals on " + enemy.gameObject.name); //debug
                break;
        }
    }

    IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(equippedMeleeWeapon.attackCooldown);
        attackOnCooldown = false;
    }

    IEnumerator DebugEnemyHitColor(Collider2D enemy)
    {
        enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        yield return new WaitForSeconds(0.5f);
        enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
