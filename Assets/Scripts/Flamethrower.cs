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
        inputKey = "1";
        name = "Flamethrower";
        description = "Primitive flamethrower built by one who dominated the slums";
        attackDamage = 10f;
        flamethrowerDuration = 3f;
        attackCooldown = 5f + flamethrowerDuration;
        flamethrowerCollider = attackPoint.GetComponent<PolygonCollider2D>();
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(enemyLayers);
        hitEnemies = new List<Collider2D>();
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;
        
        //Adjust attack damage, duration, and cooldown based on upgrade level here
    }

    public override void Upgrade()
    {
        upgradeLevel += 1;
        if (upgradeLevel == 2)
        {
            Vector2 upgrade2Point1 = new Vector2(flamethrowerCollider.points[0].x -= 1, flamethrowerCollider.points[0].y += 1);
            Vector2 upgrade2Point2 = new Vector2(flamethrowerCollider.points[1].x += 1, flamethrowerCollider.points[1].y += 1);
            Vector2[] upgradeLevel2Points = {upgrade2Point1, upgrade2Point2, flamethrowerCollider.points[2]};
            flamethrowerCollider.SetPath(0, upgradeLevel2Points);
        }
        Debug.Log("Flamethrower upgrade: " + upgradeLevel);
    }

    public override void Attack()
    {
        StartCoroutine(Activate());
        base.Attack();
        Debug.Log(playerStats.currentHealth);
    }

    IEnumerator Activate()
    {
        Debug.Log("Flamethrower activated");
        HashSet<GameObject> toExplode = new HashSet<GameObject>();

        //Slow player movement for duration
        // Also disable dashing once we optimize inputs
        playerStats.walkSpeed /= 2f;
        playerStats.runSpeed /= 2f;
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
        playerStats.walkSpeed *= 2f;
        playerStats.runSpeed *= 2f;

        //Testing final upgrade
        if (upgradeLevel == 3)
        {
            yield return new WaitForSeconds(1f); //wait for explosion
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
