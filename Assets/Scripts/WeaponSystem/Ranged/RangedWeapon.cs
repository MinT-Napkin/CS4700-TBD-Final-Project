using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public Transform attackPoint;
    public float attackCooldown = 1;
    bool attackOnCooldown = false;
    public GameObject bulletPrefab;
    public string description;
    new public string name;
    public EntityStats playerStats;
    public string inputKey;
    public bool input;

    public virtual void Awake()
    {
        inputKey = "c";
    }

    void Update()
    {
        if (input)
        {
            if (!attackOnCooldown)
                Attack();
        }
    }

    public void SetPrefab(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }

    public void SetEntityStats(EntityStats playerStats)
    {
        this.playerStats = playerStats;
    }

    void Attack(){
        SoundManager.instance.PlaySound(SoundManager.instance.rangeSound);
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
