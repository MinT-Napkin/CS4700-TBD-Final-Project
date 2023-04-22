using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackDamage;
    public float attackRange;
    public float attackCooldown;
    bool attackOnCooldown = false;
    public string description;
    public LayerMask enemyLayers;
    new public string name;
    public string inputKey;
    public EntityStats playerStats;

    public virtual void Awake()
    {
        enemyLayers = LayerMask.GetMask("Enemy");
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(inputKey))
        {
            if (!attackOnCooldown)
                Attack();
        }
    }

    public virtual void Attack()
    {
        StartCoroutine(AttackCooldown());
    }

    public void SetEntityStats(EntityStats playerStats){
        this.playerStats = playerStats;
    }

    IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        Debug.Log("Attack is on cooldown.");
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
        Debug.Log("Attack is not on cooldown.");
    }
}
