using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public BulletData bulletData;
    public RangedWeaponData equippedRangedWeapon;
    public List<RangedWeaponData> rangedWeaponList;
    bool attackOnCooldown = false;

    void Update()
    {
        bulletData.bulletStrength = equippedRangedWeapon.strength;
        bulletData.bulletSpeed = equippedRangedWeapon.bulletSpeed;
        bulletData.bulletRange = equippedRangedWeapon.attackRange;
        if (Input.GetKeyDown("c"))
        {
            if (!attackOnCooldown)
                Attack();
        }
        if (Input.GetKeyDown("l"))
        {
            RangedWeaponData toEquip = rangedWeaponList.ToArray()[1];
            if (toEquip.inInventory)
                equippedRangedWeapon = toEquip;
        }
    }

    public void Attack()
    {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        StartCoroutine(AttackCooldown());
    }

    public void SpecialAbility(GameObject enemy)
    {
        switch (equippedRangedWeapon.name)
        {
            case "Sniper Rifle":
                Debug.Log(enemy.name + " hit by " + equippedRangedWeapon.name);
                break;
        }
    }

    IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(equippedRangedWeapon.attackCooldown);
        attackOnCooldown = false;
    }
}
