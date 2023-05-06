using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangBoss : Boss
{
    public GameObject bulletPrefab;
    public BossBullet bulletData;
    public float bulletSpeed;
    public int phase;
    public float rangedAttackCooldown;
    public bool rangedAttackOnCooldown = false;
    public float rangedAttackRange;

    public bool flamethrowerEnabled = false;
    public Transform flamethrowerSpritePoint;
    public Transform flamethrowerAttackPoint;
    public float flamethrowerRange;
    public FlamethrowerEventController flamethrowerEventController;
    public float flamethrowerCooldown;
    public bool flamethrowerOnCooldown = false;

    public override void Awake()
    {
        //Add more here
        base.Awake();
        //Stats for testing
        entityStats.walkSpeed = 2f;
        entityStats.maxHealth = 100f;
        entityStats.currentHealth = 100f;
        entityStats.normalizedHealth = 1f;
        bulletData = bulletPrefab.GetComponent<BossBullet>();
        bulletData.boss = this as Boss;
        bulletData.bulletRange = rangedAttackRange;
        bulletData.bulletSpeed = this.bulletSpeed;
        phase = 1;

        flamethrowerEventController = flamethrowerSpritePoint.gameObject.GetComponent<FlamethrowerEventController>();
    }

    public override void Update()
    {
        base.Update();
        if ((entityStats.normalizedHealth <= 0.5f) && (phase < 2))
        {
            animator.SetTrigger("PhaseTransition");
            phase = 2;
            //Boost entityStats
        }

        if (flamethrowerEnabled)
        {
            if (Mathf.Abs(direction.x) > 0.80f)
            {
                if ((distance <= flamethrowerRange * 1.66f) && (!flamethrowerOnCooldown))
                {
                    flamethrowerSpritePoint.gameObject.GetComponent<Animator>().SetTrigger("Flamethrower");
                    StartCoroutine(FlamethrowerCooldown());
                }
            }
        }
    }

    protected override void OnEntityDeath()
    {
        base.OnEntityDeath();
    }

    public override void RotateEvent()
    {
        base.RotateEvent();
        attackPoint.localPosition = new Vector2(-0.082f, -0.039f);
    }

    public override void SetAttackPointDownEvent()
    {
        attackPoint.localPosition = new Vector2(0.021f, -0.167f);
    }

    public override void SetAttackPointUpEvent()
    {
        attackPoint.localPosition = new Vector2(0.013f, 0.079f);
    }

    public override void MeleeAttackEvent()
    {
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            if (phase == 1)
                Debug.Log("Phase 1 hit");
            else    
                Debug.Log("Phase 2 hit");
        }
    }

    public override void RangedAttackEvent()
    {
        Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation);
        StartCoroutine(RangedAttackCooldown());
    }

    public void FlamethrowerEventLeft()
    {
        if (Physics2D.Raycast(flamethrowerAttackPoint.position, -flamethrowerAttackPoint.right, flamethrowerRange * 2f, targetLayer).collider != null)
        {
            //Apply damage and burn
        }
        flamethrowerAttackPoint.Rotate(new Vector3(0, 0, 5));
    }

    public void FlamethrowerEventRight()
    {
        if (Physics2D.Raycast(flamethrowerAttackPoint.position, -flamethrowerAttackPoint.right, flamethrowerRange * 2f, targetLayer).collider != null)
        {
            //Apply damage and burn
        }
        flamethrowerAttackPoint.Rotate(new Vector3(0, 0, -5));
    }

    public void EnableFlamethrowerEvent()
    {
        flamethrowerSpritePoint.gameObject.SetActive(true);
        flamethrowerEnabled = true;
    }

    public void DisableFlamethrowerEvent()
    {
        flamethrowerAttackPoint.gameObject.SetActive(true);
        flamethrowerSpritePoint.gameObject.SetActive(false);
        flamethrowerEnabled = true;
    }

    IEnumerator RangedAttackCooldown()
    {
        rangedAttackOnCooldown = true;
        yield return new WaitForSeconds(rangedAttackCooldown);
        rangedAttackOnCooldown = false;
    }

    IEnumerator FlamethrowerCooldown()
    {
        flamethrowerOnCooldown = true;
        yield return new WaitForSeconds(flamethrowerCooldown);
        flamethrowerSpritePoint.gameObject.GetComponent<Animator>().ResetTrigger("Flamethrower");
        flamethrowerOnCooldown = false;
    }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangedAttackRange);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(flamethrowerSpritePoint.position, flamethrowerRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(flamethrowerAttackPoint.position, -flamethrowerAttackPoint.right * flamethrowerRange * 2f);
    }
}
