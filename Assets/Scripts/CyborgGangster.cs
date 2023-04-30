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
        //Balancing: adjust entityStats and bullet data later
        base.RangedAttack();
        Debug.Log("Cyborg gangster shoots!");
        EnemyBullet bullet = bulletPrefab.GetComponent<EnemyBullet>();
        bullet.enemy = this as Enemy;
        bullet.bulletRange = bulletRange;
        bullet.bulletSpeed = bulletSpeed;
        Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}

