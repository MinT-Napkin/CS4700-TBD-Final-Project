using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity{
    public Transform attackPoint;
    public Transform target;
    
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
                FacePlayer();
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
            if ((distance <= rangedAttackAndDetectionRange) && (distance >= chaseRange))
            {
                FacePlayer();
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

    void FacePlayer()
    {
        float rotationSpeed = 10;
        float rotationModifier = 90;
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
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
