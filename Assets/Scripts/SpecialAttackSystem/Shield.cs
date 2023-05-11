using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : SpecialAttack
{
    public float shieldDuration;
    public bool shieldActive;

    Animator animator;
    public GameObject shieldPoint;
    public override void Awake()
    {
        base.Awake();
        name = "Shield";
        description = "Shield activated by a device, often used as means of self-preservation by security robots.";
        shieldDuration = 4f;
        attackCooldown = 7f + shieldDuration;
        shieldActive = false;
        upgradeLevel = 1;
        shieldPoint = gameObject.GetComponent<PlayerClass>().shieldPoint;
        animator = shieldPoint.GetComponent<Animator>();
    }

    public override void Upgrade()
    {
        upgradeLevel += 1;
        attackCooldown -= 1f;
    }

    public override void Attack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.shieldSound);
        StartCoroutine(Activate());
        base.Attack();
    }

    public void Deactivate()
    {
        shieldActive = false;
        animator.SetTrigger("DeactivateShield");
        animator.ResetTrigger("ActivateShield");
        if (upgradeLevel > 1)
        {
            gameObject.GetComponent<PlayerClass>().ShieldHeal();
        }
    }

    IEnumerator Activate()
    {
        shieldActive = true;
        animator.SetTrigger("ActivateShield");
        animator.ResetTrigger("DeactivateShield");
        yield return new WaitForSeconds(shieldDuration);
        if (shieldActive)
            Deactivate();
    }
}
