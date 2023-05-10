using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangBoss : Boss
{
    public GameObject bossObstacle;
    public GameObject bulletPrefab;
    public BossBullet bulletData;
    public float bulletSpeed;
    public int phase;
    public float rangedAttackCooldown;
    public bool rangedAttackOnCooldown = false;
    public float rangedAttackRange;

    public bool flamethrowerEnabled = false;
    public Transform flamethrowerHorizontalSpritePoint;
    public Transform flamethrowerHorizontalAttackPoint;
    public Transform flamethrowerUpSpritePoint;
    public Transform flamethrowerUpAttackPoint;
    public Transform flamethrowerDownSpritePoint;
    public Transform flamethrowerDownAttackPoint;
    public float flamethrowerRange;
    public FlamethrowerHorizontalEventController flamethrowerHorizontalEventController;
    public float flamethrowerCooldown;
    public bool flamethrowerOnCooldown = false;

    public Transform activeFlamethrowerSpritePoint;

    public override void Awake()
    {
        base.Awake();
        bulletData = bulletPrefab.GetComponent<BossBullet>();
        bulletData.boss = this as Boss;
        bulletData.bulletRange = rangedAttackRange;
        bulletData.bulletSpeed = this.bulletSpeed;
        phase = 1;
        flamethrowerHorizontalEventController = flamethrowerHorizontalSpritePoint.gameObject.GetComponent<FlamethrowerHorizontalEventController>();
    }

    public override void Update()
    {
        base.Update();

        if (flamethrowerEnabled)
        {
            if ((distance <= flamethrowerRange * 1.66f) && (!flamethrowerOnCooldown))
                StartCoroutine(FlamethrowerCooldown());
        }

        Debug.Log(flamethrowerHorizontalAttackPoint.rotation);
    }

    protected override void DamageHealth(float finalDamage)
    {
        base.DamageHealth(finalDamage);
        if ((entityStats.normalizedHealth <= 0.5f) && (phase < 2))
        {
            animator.SetTrigger("PhaseTransition");
            phase = 2;
            //Boost entityStats
        }
    }

    protected override void OnEntityDeath()
    {
        base.OnEntityDeath();
    }

    public override void AfterDeathAnimation()
    {
        bossObstacle.GetComponent<BossObstacle>().despawnBossObstacle();
        base.AfterDeathAnimation();
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
                Debug.Log("Phase 1 hit"); //Damage
            else    
                Debug.Log("Phase 2 hit"); //Damage + burn status
        }
    }

    public override void RangedAttackEvent()
    {
        Instantiate(bulletPrefab, rangedAttackPoint.position, rangedAttackPoint.rotation);
        StartCoroutine(RangedAttackCooldown());
    }

    public void FlamethrowerEventLeft()
    {
        if (Physics2D.Raycast(flamethrowerHorizontalAttackPoint.position, -flamethrowerHorizontalAttackPoint.right, flamethrowerRange * 2f, targetLayer).collider != null)
        {
            //Apply damage and burn
            Debug.Log("Burned!");
        }
        flamethrowerHorizontalAttackPoint.Rotate(new Vector3(0, 0, 2.9545f));
    }

    public void FlamethrowerEventRight()
    {
        if (Physics2D.Raycast(flamethrowerHorizontalAttackPoint.position, -flamethrowerHorizontalAttackPoint.right, flamethrowerRange * 2f, targetLayer).collider != null)
        {
            //Apply damage and burn
            Debug.Log("Burned!");
        }
        flamethrowerHorizontalAttackPoint.Rotate(new Vector3(0, 0, -2.9545f));
    }

    public void FlamethrowerEventUp()
    {
        if (Physics2D.Raycast(flamethrowerUpAttackPoint.position, flamethrowerUpAttackPoint.up, flamethrowerRange * 2f, targetLayer).collider != null)
        {
            //Apply damage and burn
            Debug.Log("Burned!");
        }
        flamethrowerUpAttackPoint.Rotate(new Vector3(0, 0, 2.9545f));
    }

    public void FlamethrowerEventDown()
    {
        if (Physics2D.Raycast(flamethrowerDownAttackPoint.position, -flamethrowerDownAttackPoint.up, flamethrowerRange * 2f, targetLayer).collider != null)
        {
            //Apply damage and burn
            Debug.Log("Burned!");
        }
        flamethrowerDownAttackPoint.Rotate(new Vector3(0, 0, 2.8260f));
    }

    public void EnableFlamethrowerEvent()
    {
        flamethrowerHorizontalSpritePoint.gameObject.SetActive(true);
        flamethrowerUpSpritePoint.gameObject.SetActive(false);
        flamethrowerDownSpritePoint.gameObject.SetActive(false);
        activeFlamethrowerSpritePoint = flamethrowerHorizontalSpritePoint;
        flamethrowerEnabled = true;
    }

    public void SetActiveFlamethrowerSpritePointUpEvent()
    {
        flamethrowerHorizontalSpritePoint.gameObject.SetActive(false);
        flamethrowerDownSpritePoint.gameObject.SetActive(false);
        flamethrowerUpSpritePoint.gameObject.SetActive(true);
        activeFlamethrowerSpritePoint = flamethrowerUpSpritePoint;
    }

    public void SetActiveFlamethrowerSpritePointDownEvent()
    {
        flamethrowerHorizontalSpritePoint.gameObject.SetActive(false);
        flamethrowerUpSpritePoint.gameObject.SetActive(false);
        flamethrowerDownSpritePoint.gameObject.SetActive(true);
        activeFlamethrowerSpritePoint = flamethrowerDownSpritePoint;
    }

    public void DisableFlamethrowerEvent()
    {
        flamethrowerHorizontalAttackPoint.gameObject.SetActive(false);
        flamethrowerHorizontalSpritePoint.gameObject.SetActive(false);
        flamethrowerUpAttackPoint.gameObject.SetActive(false);
        flamethrowerUpSpritePoint.gameObject.SetActive(false);
        flamethrowerDownSpritePoint.gameObject.SetActive(false);
        flamethrowerDownAttackPoint.gameObject.SetActive(false);
        flamethrowerEnabled = false;
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
        activeFlamethrowerSpritePoint.gameObject.GetComponent<Animator>().SetTrigger("Flamethrower");
        yield return new WaitForSeconds(1f);
        activeFlamethrowerSpritePoint.gameObject.GetComponent<Animator>().ResetTrigger("Flamethrower");
        yield return new WaitForSeconds(flamethrowerCooldown);
        flamethrowerOnCooldown = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, initiateRange);

        Gizmos.color = new Color(141/255f, 13/255f, 225/255f);
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangedAttackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(flamethrowerUpAttackPoint.position, flamethrowerUpAttackPoint.up * flamethrowerRange * 2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(flamethrowerHorizontalAttackPoint.position, -flamethrowerHorizontalAttackPoint.right * flamethrowerRange * 2f);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(flamethrowerDownAttackPoint.position, -flamethrowerDownAttackPoint.up * flamethrowerRange * 2f);
    }
}
