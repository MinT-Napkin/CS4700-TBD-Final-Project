using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SpecialAttack{
    public PolygonCollider2D flamethrowerCollider;
    public float flamethrowerDuration;
    ContactFilter2D contactFilter;
    List<Collider2D> hitEnemies;

    InputController inputController;
    Animator animator;

    //Level 1 attack point positions
    public Vector2 upgrade1Left = new Vector2(-1.91799998f,-0.104999997f);
    public Vector2 upgrade1Right = new Vector2(1.73599994f,-0.377000004f);
    public Vector2 upgrade1Up = new Vector2(0.0149999997f,1.36099994f);
    public Vector2 upgrade1Down = new Vector2(-0.180000007f,-2.06999993f);

    //Level 2 attack point positions
    public Vector2 upgrade2Left = new Vector2(-3.04999989f, -0.159999996f);
    public Vector2 upgrade2Right = new Vector2(3.1400001f, -0.159999996f);
    public Vector2 upgrade2Up = new Vector2(0.100000001f, 2.67000008f);
    public Vector2 upgrade2Down = new Vector2(-0.180000007f, -3.28999996f);


    public override void Awake(){
        base.Awake();
        name = "Flamethrower";
        damageType = new DamageTypeFire();
        description = "Primitive flamethrower built by one who dominated the slums";
        attackDamage = 1.0f;
        flamethrowerDuration = 3.0f;
        attackCooldown = 5.0f + flamethrowerDuration;
        attackPoint = gameObject.GetComponent<PlayerClass>().flamethrowerAttackPoint;
        flamethrowerCollider = attackPoint.GetComponent<PolygonCollider2D>();
        //set animator
        animator = attackPoint.gameObject.GetComponent<Animator>();
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
            attackPoint.localScale = new Vector3(6.66726303f,6.66726303f,6.66726303f);
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
        inputController.EnableDash(false);
        animator.SetTrigger("Flamethrower");
        animator.ResetTrigger("EndFlamethrower");
        for (int i = 0; i < flamethrowerDuration * 2; i++){
            flamethrowerCollider.OverlapCollider(contactFilter, hitEnemies);

            foreach (Collider2D enemy in hitEnemies){
                //Implement damage and status effect here
                damageEvent = new DamageEvent(attackDamage, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), enemy.gameObject.GetComponent<Entity>(), DamageCategory.Special);
                
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
        inputController.EnableDash(true);
        animator.SetTrigger("EndFlamethrower");
        animator.ResetTrigger("Flamethrower");

        //Testing final upgrade
        if (upgradeLevel >= 3){
             //wait for explosion

            foreach (GameObject enemy in toExplode){
                GameObject explosionPrefab = (GameObject)Resources.Load("Inguz Media Studio/Free 2D Impact FX/Prefabs/Impact02");
                enemy.GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForSeconds(2f);
                Instantiate(explosionPrefab, enemy.transform.position, enemy.transform.rotation);
                foreach (Collider2D element in Physics2D.OverlapCircleAll(enemy.gameObject.transform.position, 2f, enemyLayers)){
                    damageEvent = new DamageEvent(attackDamage, damageType, attackPoint.parent.gameObject.GetComponent<PlayerClass>(), element.gameObject.GetComponent<Entity>(), DamageCategory.Special);
                    element.gameObject.GetComponent<Entity>().TakeDamage(damageEvent);
                enemy.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
        hitEnemies.Clear();
    }
}
