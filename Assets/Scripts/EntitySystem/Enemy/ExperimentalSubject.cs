using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperimentalSubject : EnemyMeleeAndRanged
{
    /*
    For animations:
    aiPath.maxSpeed = 0f; and freezeRotation = true/false used to stop enemy movement durign certain animations.
    Experimental Subject is bulky, therefore moves slowly. Has a high ranged attack range, moderate chase range, relatively small melee attack range.
    Melee Attack: Combo of 2, fast and consecutive punches, dealing massive damage. (the time between two punches can be adjusted with comboSpeed)
    RangedAttack: Lightning bolt ray with a short wind up. Damages and stuns player. Lightning damage.
    Balacning: adjust entitystats, combospeed later
    */
    public float comboSpeed;

    public override void MeleeAttack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.ESMeleeSound);
        StartCoroutine(DemonstrateMeleeAttack());
        base.MeleeAttack();
    }

    public override void RangedAttack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.ESRangeSound);
        StartCoroutine(DemonstrateRangedAttack());
        base.RangedAttack();
    }

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
    }

    IEnumerator DemonstrateRangedAttack()
    {
        Vector2 newDirection = direction;
        yield return new WaitForSeconds(0.3f);
        RaycastHit2D targetHit = Physics2D.Raycast(attackPoint.position, newDirection, rangedAttackRange, targetLayer);
        if (targetHit.collider != null)
            Debug.Log(targetHit.collider.gameObject.name);
            //Apply stun
        for (int i = 0; i < 20; i++)
        {
            Debug.DrawRay(attackPoint.position, newDirection * rangedAttackRange);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
