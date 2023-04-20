using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public BulletController bulletController;
    public float attackCooldown;
    //public RangedWeaponData equippedRangedWeapon;
    //public List<RangedWeaponData> rangedWeaponInventory;
    bool attackOnCooldown = false;

    void Awake()
    {
        bulletController = bulletPrefab.GetComponent<BulletController>();
    }

    void Update()
    {
        /*
        bulletController.bulletStrength = equippedRangedWeapon.strength;
        bulletController.bulletSpeed = equippedRangedWeapon.bulletSpeed;
        bulletController.bulletRange = equippedRangedWeapon.attackRange;
        */
        if (Input.GetKeyDown("c"))
        {
            if (!attackOnCooldown)
                Attack();
        }
        /*
        if (Input.GetKeyDown("l"))
        {
            equippedRangedWeapon = rangedWeaponInventory.ToArray()[1];
        }
        */
    }

    public void Attack()
    {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        StartCoroutine(AttackCooldown());
    }

    public void SpecialAbility()
    {

    }

    IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }
}
