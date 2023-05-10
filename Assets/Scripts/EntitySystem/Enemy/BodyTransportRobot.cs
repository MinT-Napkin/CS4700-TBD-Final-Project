using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyTransportRobot : EnemyMelee
{
    /*
    For animations:
    freezeRotation = true/false; and entityStats.walkSpeed is used to stop enemy movement while executing an attack animation
    BodyTransportRobots move relatively slow when not attacking. Its melee attack: winds up before performing a quick, damage dealing charge at the player,
    followed by a series of melee coffin attacks. After performing the move, it has takes a while to regenerate and start moving again. (like 2 seconds maybe)
    
    NOTE: As this one behaves a little differently, it overrides the Update() method. It does NOT use the ai path to chase player around obstacles (this one's pretty dumb and gets stuck on walls).
    For this enemy, only use meleeDetectionRange, not chaseRange.

    Balacning: Adjust entityStats later
    */

    //Leaving coroutines in here to demonstrate behavior, we might need them for the charge speed up anyway

    public float chargeSpeed;
    public float chargeDuration;
    Rigidbody2D rb2d;
    bool charging = false;

    public int coffinSlamCount;
    public float coffinSlamFrequency;

    public override void Awake()
    {
        base.Awake();
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.gravityScale = 0f;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public override void Update()
    {
        distance = Vector2.Distance(target.position, transform.position);
        direction = target.position - transform.position;
        
        direction.Normalize();
        if (distance <= meleeDetectionRange)
        {
            if (!charging)
                rb2d.velocity = direction * entityStats.walkSpeed;
            RotateEnemy();
            if (!meleeAttackOnCooldown)
                MeleeAttack();
        }
    }

    public override void MeleeAttack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.BTRMeleeSound);
        base.MeleeAttack();
        StartCoroutine(DemonstrateAttack());
    }

    IEnumerator DemonstrateAttack()
    {
        charging = true;
        rb2d.velocity = direction * chargeSpeed;
        yield return new WaitForSeconds(chargeDuration);
        rb2d.velocity = Vector3.zero;
        yield return new WaitForSeconds(0.5f); //wait before performing the series of coffin slams
        for (int i = 0; i < coffinSlamCount; i++)
        {
            Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
            if (targetHit != null)
                Debug.Log(targetHit.gameObject.name + " hit by BodyTransportRobot!");
            yield return new WaitForSeconds(coffinSlamFrequency);
        }
        yield return new WaitForSeconds(2f); //Regenerate before starts moving again
        charging = false;
    }

    //Charge damage detection
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.tag == "Player")
        {
            //Deal damage to player
            Debug.Log("Player hit");
        }
    }
}
