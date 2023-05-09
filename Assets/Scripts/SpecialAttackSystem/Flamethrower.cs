using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SpecialAttack{
    public PolygonCollider2D flamethrowerCollider;
    public float flamethrowerDuration;
    ContactFilter2D contactFilter;
    List<Collider2D> hitEnemies;

    InputController inputController;


    public override void Awake(){
        base.Awake();
        name = "Flamethrower";
        damageType = new DamageTypePhysical();
        description = "Primitive flamethrower built by one who dominated the slums";
        attackDamage = 1.0f;
        flamethrowerDuration = 3.0f;
        attackCooldown = 5.0f + flamethrowerDuration;
        flamethrowerCollider = attackPoint.GetComponent<PolygonCollider2D>();
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(enemyLayers);
        hitEnemies = new List<Collider2D>();
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;

        inputController = gameObject.GetComponent<InputController>();

        //Adjust attack damage, duration, and cooldown based on upgrade level here
    }

    public override void Upgrade(){
        upgradeLevel += 1;

        if (upgradeLevel == 2){
            Vector2 upgrade2Point1 = new Vector2(flamethrowerCollider.points[0].x -= 1, flamethrowerCollider.points[0].y += 1);
            Vector2 upgrade2Point2 = new Vector2(flamethrowerCollider.points[1].x += 1, flamethrowerCollider.points[1].y += 1);
            Vector2[] upgradeLevel2Points = {upgrade2Point1, upgrade2Point2, flamethrowerCollider.points[2]};
            flamethrowerCollider.SetPath(0, upgradeLevel2Points);
        }
    }

    public override void Attack(){
        SoundManager.instance.PlaySound(SoundManager.instance.flamethrowerSound);
        StartCoroutine(Activate());
        base.Attack();
    }

    IEnumerator Activate(){
        DamageEvent damageEvent;
        HashSet<GameObject> toExplode = new HashSet<GameObject>();

        //Slow player movement for duration
        // Also disable dashing once we optimize inputs
        flamethrowerCollider.enabled = true;
        playerStats.walkSpeed /= 2f;
        playerStats.runSpeed /= 2f;
        for (int i = 0; i < flamethrowerDuration * 2; i++){
            flamethrowerCollider.OverlapCollider(contactFilter, hitEnemies);

            foreach (Collider2D enemy in hitEnemies){
                //Implement damage and status effect here
                damageEvent = new DamageEvent(attackDamage, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Entity>());
                
                //Apply burn status effect
                enemy.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
                //Final upgrade
                toExplode.Add(enemy.gameObject);
            }
            yield return new WaitForSeconds(0.5f);
        }
        flamethrowerCollider.enabled = false;
        playerStats.walkSpeed *= 2f;
        playerStats.runSpeed *= 2f;

        //Testing final upgrade
        if (upgradeLevel >= 3){
            yield return new WaitForSeconds(1f); //wait for explosion

            foreach (GameObject enemy in toExplode){
                foreach (Collider2D element in Physics2D.OverlapCircleAll(enemy.gameObject.transform.position, 3f, enemyLayers)){
                    damageEvent = new DamageEvent(attackDamage * 3, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), element.gameObject.GetComponent<Entity>());
                    element.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
                }
            }
        }
        hitEnemies.Clear();
    }

    IEnumerator DebugColorCoroutine(GameObject enemy, Color color){
        enemy.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(2f);
        enemy.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
