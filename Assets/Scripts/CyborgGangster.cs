using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CyborgGangster : EnemyRanged
{
    public float bulletRange;
    public float bulletSpeed;
    public GameObject bulletPrefab;

    public override void RangedAttack()
    {
        /*Balancing: adjust entityStats and bullet data later
        The cyborg gangster walks up to the player slowly but flees quickly when the player gets too close
        Moderate shooting speed, for a regular pistol. Has lower chase range thatn the police robot.*/
        base.RangedAttack();
        Debug.Log("Cyborg gangster shoots!");
        EnemyBullet bullet = bulletPrefab.GetComponent<EnemyBullet>();
        bullet.enemy = this as Enemy;
        bullet.bulletRange = bulletRange;
        bullet.bulletSpeed = bulletSpeed;
        Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}

