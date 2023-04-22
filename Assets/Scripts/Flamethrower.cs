using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SpecialAttack
{
    public Collider2D flamethrowerCollider;
    public float flamethrowerDuration;
    ContactFilter2D contactFilter;
    List<Collider2D> hitEnemies;

    public override void Awake()
    {
        base.Awake();
        attackDamage = 10f;
        attackRange = 10f;
        attackCooldown = 5f;
        inputKey = "f";
        name = "Flamethrower";
        description = "Primitive flamethrower built by one who dominated the slums";
        flamethrowerDuration = 3f;
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(enemyLayers);
        hitEnemies = new List<Collider2D>();
    }

    public override void Attack()
    {
        StartCoroutine(Activate());
        base.Attack();
    }

    IEnumerator Activate()
    {
        for (int i = 0; i < flamethrowerDuration; i++)
        {
            flamethrowerCollider.OverlapCollider(contactFilter, hitEnemies);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log(enemy.gameObject.name);
            }
            yield return new WaitForSeconds(1f);
        }
        hitEnemies.Clear();
    }
}
