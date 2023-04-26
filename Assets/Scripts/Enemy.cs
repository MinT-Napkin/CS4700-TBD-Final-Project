using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity{

    public Transform attackPoint;
    public Transform target;
    public LayerMask targetLayer;
    
    public bool hasMeleeAttack;
    public bool hasRangedAttack;

    public float meleeAttackRange;
    public float meleeDetectionRange;
    public float chaseRange;
    public float rangedAttackAndDetectionRange;

    public float meleeAttackSpeed;
    public float rangedAttackSpeed;

    public bool meleeAttackOnCooldown = false;
    public bool rangedAttackOnCooldown = false;

    protected bool freezeRotation = false;

    void Awake()
    {
        target = GameObject.FindWithTag("Player").transform;
        targetLayer = LayerMask.GetMask("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        
        if (hasMeleeAttack)
        {
            if (distance <= chaseRange)
            {
                RotateEnemy();
                if (distance > meleeDetectionRange)
                {
                    transform.position = Vector2.MoveTowards(transform.position, target.position, entityStats.walkSpeed * Time.deltaTime);
                }
                else if (distance <= meleeDetectionRange)
                {
                    if (!meleeAttackOnCooldown)
                        MeleeAttack();
                }
            }
        }

        if (hasRangedAttack)
        {
            if (!hasMeleeAttack) //For enemies who ONLY have a ranged attack, therefore those behaving differently
            {
                if (distance <= chaseRange)
                {
                    RotateEnemy();
                    if (distance > rangedAttackAndDetectionRange)
                    {
                        transform.position = Vector2.MoveTowards(transform.position, target.position, entityStats.walkSpeed * Time.deltaTime);
                    }
                    else if (distance <= rangedAttackAndDetectionRange)
                    {
                        if (!rangedAttackOnCooldown)
                            RangedAttack();
                    }
                }
            }
            else if ((distance <= rangedAttackAndDetectionRange) && (distance >= chaseRange))
            {
                RotateEnemy();
                if (!rangedAttackOnCooldown)
                    RangedAttack();
            }
        }
    }

    public virtual void MeleeAttack(){
       StartCoroutine(MeleeAttackCooldown());
    }

    public virtual void RangedAttack(){
        StartCoroutine(RangedAttackCooldown());
    }

    protected override void OnEntityDeath(){
    }

    void RotateEnemy()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        
        if (!freezeRotation)
        {
            if (direction.y < -0.5f)
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
            else if (direction.y > 0.5f)
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            else if (direction.x < 0)
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
            else if (direction.x > 0)
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
        }
    }

    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeDetectionRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangedAttackAndDetectionRange);
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
