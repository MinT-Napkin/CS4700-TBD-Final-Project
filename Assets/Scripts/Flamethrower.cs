using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SpecialAttack
{
    public PolygonCollider2D flamethrowerCollider;
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
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;
    }

    public override void Attack()
    {
        StartCoroutine(Activate());
        base.Attack();
    }

    IEnumerator Activate()
    {
        HashSet<GameObject> toExplode = new HashSet<GameObject>();

        for (int i = 0; i < flamethrowerDuration * 2; i++)
        {
            flamethrowerCollider.OverlapCollider(contactFilter, hitEnemies);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log(enemy.gameObject.name + " hit by flamethrower.");
                //Implement damage and status effect here

                //Testing final upgrade
                toExplode.Add(enemy.gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
        
        //Testing final upgrade
        if (upgradeLevel == 3)
        {
            foreach (GameObject enemy in toExplode)
            {
                Debug.Log("Explosion created on " + enemy.name);
                foreach (Collider2D element in Physics2D.OverlapCircleAll(enemy.gameObject.transform.position, 3f, enemyLayers))
                {
                    // Might get rid of this check and damage the enemy that expldoes as well, I put this here for debugging to make it clear which one explodes and which are damaged by the explosion
                    if (enemy.gameObject != element.gameObject)
                    {
                        StartCoroutine(DebugColorCoroutine(element.gameObject, Color.yellow)); //Yellow enemies are hit by explosion
                        Debug.Log(element.gameObject.name + " hit by explosion!");
                    }
                }
            }
        }
        hitEnemies.Clear();
    }

    IEnumerator DebugColorCoroutine(GameObject enemy, Color color)
    {
        enemy.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(2f);
        enemy.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
