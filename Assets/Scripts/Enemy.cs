using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity{
    public Transform meleeAttackPoint;
    public Transform rangedAttackPoint;
    public Transform target;
    
    public bool hasMeleeAttack;
    public bool hasRangedAttack;

    public float meleeAttackRange;
    public float chaseRange;
    public float rangedAttackRange;

    public float meleeAttackSpeed;
    public float rangedAttackSpeed;

    public bool meleeAttackOnCooldown = false;
    public bool rangedAttackOnCooldown = false;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        
        if (hasMeleeAttack)
        {
            if (distance <= chaseRange)
            {
                if (distance > meleeAttackRange)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, entityStats.walkSpeed * Time.deltaTime);
                }
                else if (distance <= meleeAttackRange)
                {
                    if (!meleeAttackOnCooldown)
                        MeleeAttack();
                }
            }
        }

        if (hasRangedAttack)
        {
            if ((distance <= rangedAttackRange) && (distance >= chaseRange))
            {
                if (!rangedAttackOnCooldown)
                    RangedAttack();
            }
        }
    }

    //Attack methods are overridden in specific enemy scripts, attached to prefab variants for those specific enemies
    public virtual void MeleeAttack(){
       StartCoroutine(MeleeAttackCooldown());
    }

    public virtual void RangedAttack(){
        StartCoroutine(RangedAttackCooldown());
    }

    protected override void OnEntityDeath(){
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeAttackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangedAttackRange);
    }

    IEnumerator MeleeAttackCooldown()
    {
        meleeAttackOnCooldown = true;
        yield return new WaitForSeconds(meleeAttackSpeed);
        meleeAttackOnCooldown = false;
    }

    IEnumerator RangedAttackCooldown()
    {
        rangedAttackOnCooldown = true;
        yield return new WaitForSeconds(rangedAttackSpeed);
        rangedAttackOnCooldown = false;
    }
}
