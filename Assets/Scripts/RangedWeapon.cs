using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject bulletPrefab;
    public float attackCooldown = 1;
    bool attackOnCooldown = false;

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (!attackOnCooldown)
                Attack();
        }
    }

    void Attack()
    {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }
}
