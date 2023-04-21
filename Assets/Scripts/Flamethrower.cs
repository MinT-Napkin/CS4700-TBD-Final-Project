using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SpecialAttack
{
    public Collider2D flamethrowerCollider;

    public override void Awake()
    {
        base.Awake();
        attackDamage = 10f;
        attackRange = 10f;
        attackCooldown = 5f;
        inputKey = "f";
        name = "Flamethrower";
        description = "Primitive flamethrower built by one who dominated the slums";
    }

    public override void Attack()
    {
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(enemyLayers);
        List<Collider2D> hitEnemies = new List<Collider2D>();
        flamethrowerCollider.OverlapCollider(contactFilter, hitEnemies);
        //debugging
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log(enemy.gameObject.name);
            //StartCoroutine(Use(enemy));
        }
        base.Attack();
    }

    /*
    IEnumerator Use(Collider2D enemy)
    {
        //Damage overtime + apply burn status
    }
    */
}
