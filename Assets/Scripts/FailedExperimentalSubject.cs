using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedExperimentalSubject : EnemyMeleeAndRanged
{
    /*high chase range and walkSpeed!
    aiPath.maxSpeed; is used to stop enemy movement during certain animations
    MeleeAttack: Fast claw slashes, triple attack that causes poison. Does not deal as much damage as Experimental Subject's melee punches.
    RangedAttacK: Poison spit in a cone-like area over a set time, similarily to the flamethrower ability. Causes poison.
    */

    public PolygonCollider2D poisonSpitCollider;
    public float poisonSpitDuration; //use this later
    ContactFilter2D contactFilter;
    public float comboSpeed;

    public override void Awake()
    {
        base.Awake();
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(targetLayer);
    }

    public override void MeleeAttack()
    {
        StartCoroutine(DemonstrateMeleeAttack());
        base.MeleeAttack();
    }

    public override void RangedAttack()
    {
        StartCoroutine(DemonstrateRangedAttack());
        base.RangedAttack();
    }

    //Again, coroutine to demonstrate

    //Apply poison
    IEnumerator DemonstrateMeleeAttack()
    {
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            Debug.Log(targetHit.gameObject.name + "hit by first attack.");
            targetHit.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            targetHit.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        yield return new WaitForSeconds(comboSpeed);
        targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            Debug.Log(targetHit.gameObject.name + "hit by second attack.");
            targetHit.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            targetHit.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        yield return new WaitForSeconds(comboSpeed);
        targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            Debug.Log(targetHit.gameObject.name + "hit by third attack.");
            targetHit.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            targetHit.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }

    IEnumerator DemonstrateRangedAttack()
    {
        aiPath.maxSpeed /= 2f;
        freezeRotation = true;
        Quaternion q = Quaternion.AngleAxis((Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90), Vector3.forward);
        attackPoint.rotation = Quaternion.Slerp(attackPoint.rotation, q, 20);
        poisonSpitCollider.enabled = true;
        for (int i = 0; i < poisonSpitDuration * 2f; i++)
        {
            int targetHit = poisonSpitCollider.OverlapCollider(contactFilter, new Collider2D[1]);
            if (targetHit > 0)
                Debug.Log("Player hit by poison spit!");
            yield return new WaitForSeconds(0.5f);
        }
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
        poisonSpitCollider.enabled = false;
    }
}
