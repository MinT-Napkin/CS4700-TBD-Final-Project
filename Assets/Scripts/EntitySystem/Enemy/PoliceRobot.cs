using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceRobot : EnemyMeleeAndRanged
{
    public float bulletRange;
    public float bulletSpeed;
    public GameObject bulletPrefab;

    public override void MeleeAttack()
    {
        /*
        For animations:
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        The police robot moves relatively slow, shoots fast series of bullets (Hope we can pull this off without looking TOO funky with the animation we have, but i wanted to make this one a bit different)
        Its melee attacks are relatively slow (wind up and wind down time), but not as slow as the mob gangster's. Has high chase range.
        */
        SoundManager.instance.PlaySound(SoundManager.instance.PRMeleeSound);
        base.MeleeAttack();
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
        Collider2D targetHit = Physics2D.OverlapCircle(attackPoint.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit by Police Robot!");
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }

    public override void RangedAttack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.PRRangeSound);
        base.RangedAttack();
        Debug.Log("Police robot shoots shoots!");
        EnemyBullet bullet = bulletPrefab.GetComponent<EnemyBullet>();
        bullet.enemy = this as Enemy;
        bullet.bulletRange = bulletRange;
        bullet.bulletSpeed = bulletSpeed;
        Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
