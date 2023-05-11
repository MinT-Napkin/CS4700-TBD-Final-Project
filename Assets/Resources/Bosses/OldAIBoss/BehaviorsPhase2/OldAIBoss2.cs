using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAIBoss2 : Boss
{
    public GameObject bossObstacle;
    public float attackCooldown;
    public bool attackOnCooldown = false;
    public Transform AOEAttackPoint;
    public float AOEAttackRange;

    //Initiate dash when player between dash distance 1 and 2, and when dash not on cooldown
    public float initiateDashRange1;
    public float initiateDashRange2;
    public float dashSpeed;
    public float maxDashDistance;
    public float dashCooldown;
    public bool dashCollisionEnabled = false;
    public bool dashOnCooldown = false;
    public override void Awake()
    {
        base.Awake();
        //Test entity stats
        entityStats.walkSpeed = 2f;
        entityStats.currentHealth = 50f;
        entityStats.maxHealth = 50f;
        entityStats.normalizedHealth = 1f;
        healthbar.gameObject.SetActive(true);
        bossObstacle = GameObject.FindWithTag("BossObstacle");
    }

    public override void Update()
    {
        base.Update();
        if ((!dashOnCooldown) && (distance <= initiateDashRange1) && (distance >= initiateDashRange2))
        {
            animator.SetTrigger("Dash");
            StartCoroutine(DashCooldownCoroutine());
        }
    }

    public override void RotateEvent()
    {
        base.RotateEvent();
        attackPoint.localPosition = new Vector2(-0.1f, -0.008f);
    }

    public override void SetAttackPointDownEvent()
    {
        attackPoint.localPosition = new Vector2(-0.019f,-0.075f);
    }

    public override void SetAttackPointUpEvent()
    {
        attackPoint.localPosition = new Vector2(-0.028f,0.112f);
    }

    public override void MeleeAttackEvent()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.oldAIBossMeleeSound);
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
        {
            //Apply damage
            Debug.Log(targetHit.gameObject.name + " phase 2 hit!");
        }
    }

    public void AOEAttackEvent()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.oldAIBossAOESound);
        Collider2D targetHit = Physics2D.OverlapCircle(AOEAttackPoint.position, AOEAttackRange, targetLayer);
        if (targetHit != null)
        {
            //Apply damage
            Debug.Log(targetHit.gameObject.name + " AOE hit!");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        SoundManager.instance.PlaySound(SoundManager.instance.oldAIBossDashSound);
        if (dashCollisionEnabled)
        {
            if (other.collider.gameObject.tag == "Player")
            {
                //damage player
                //Very short stun
                Debug.Log("Player hit with dash!");
            }
        }
        EmergencyStopDashEvent();
        animator.SetTrigger("EndDash");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, initiateRange);

        Gizmos.color = new Color(141/255f, 13/255f, 225/255f);
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AOEAttackPoint.position, AOEAttackRange);

        Gizmos.color = new Color(242/255f, 7/255f, 160/255f);
        Gizmos.DrawWireSphere(transform.position, initiateDashRange1);

        Gizmos.color = new Color(237/255f, 147/255f, 206/255f);
        Gizmos.DrawWireSphere(transform.position, initiateDashRange2);
    }

    public void AttackCooldown()
    {
        StartCoroutine(AttackCooldownCoroutine());
    }

    IEnumerator AttackCooldownCoroutine()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }

    IEnumerator DashCooldownCoroutine()
    {
        dashOnCooldown = true;
        yield return new WaitForSeconds(dashCooldown);
        dashOnCooldown = false;
    }

    public void EmergencyStopDashEvent()
    {
        rb2d.velocity = Vector3.zero;
    }

    public override void AfterDeathAnimation()
    {
        base.AfterDeathAnimation();
        bossObstacle.GetComponent<BossObstacle>().despawnBossObstacle();
    }
}
