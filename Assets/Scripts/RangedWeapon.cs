using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour{
    public Transform attackPoint;
    public float attackCooldown = 1;
    bool attackOnCooldown = false;
    public GameObject bulletPrefab;
    public string description;
    new public string name;
    public EntityStats playerStats;

    public virtual void Awake(){
    }

    void Update(){
        if (Input.GetKeyDown("c"))
        {
            if (!attackOnCooldown)
                Attack();
        }
    }

    public void SetPrefab(GameObject bulletPrefab){
        this.bulletPrefab = bulletPrefab;
    }

    public void SetEntityStats(EntityStats playerStats) {
        this.playerStats = playerStats;
    }

    void Attack(){
        
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown(){
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }
}
