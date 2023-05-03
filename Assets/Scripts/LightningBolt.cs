using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBolt : SpecialAttack
{
    public float lightningBoltRange;

    public override void Awake()
    {
        base.Awake();
        name = "Lightning Bolt";
        description = "Lightning bolt created by a traditional, military-grade weapon. This technology is used in many kinds of weaponry.";
        attackDamage = 10f;
        attackCooldown = 5f;
        lightningBoltRange = 10f;
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;

        //Adjust damage and cooldown based on upgrade level here
    }

    public override void Upgrade()
    {
        upgradeLevel += 1;
        Debug.Log("Lightning bolt upgrade: " + upgradeLevel);
    }

    public override void Attack()
    {
        StartCoroutine(Activate());
        StartCoroutine(DebugRay());
        base.Attack();
    }

    IEnumerator Activate()
    {
        RaycastHit2D[] hitEnemies1 = new List<RaycastHit2D>().ToArray();
        RaycastHit2D[] hitEnemies2 = new List<RaycastHit2D>().ToArray();
        RaycastHit2D[] hitEnemies3 = new List<RaycastHit2D>().ToArray();

        yield return new WaitForSeconds(0.8f);
        hitEnemies1 = Physics2D.RaycastAll(attackPoint.position, attackPoint.up, lightningBoltRange, enemyLayers);
        if (upgradeLevel > 1)
        {
            attackPoint.Rotate(new Vector3(0f, 0f, -35f));
            hitEnemies2 = Physics2D.RaycastAll(attackPoint.position, attackPoint.up, lightningBoltRange, enemyLayers);
            attackPoint.Rotate(new Vector3(0f, 0f, 70f));
            hitEnemies3 = Physics2D.RaycastAll(attackPoint.position, attackPoint.up, lightningBoltRange, enemyLayers);
            attackPoint.Rotate(new Vector3(0f, 0f, -35f));
        }
        foreach (RaycastHit2D enemy in hitEnemies1)
        {
            Debug.Log(enemy.collider.gameObject.name);
            if (upgradeLevel > 2)
            {
                //Apply stun
                Debug.Log(enemy.collider.gameObject.name + " stunned!");
            }
        }
        foreach (RaycastHit2D enemy in hitEnemies2)
        {
            Debug.Log(enemy.collider.gameObject.name);
            if (upgradeLevel > 2)
            {
                //Apply stun
                Debug.Log(enemy.collider.gameObject.name + " stunned!");
            }
        }
        foreach (RaycastHit2D enemy in hitEnemies3)
        {
            Debug.Log(enemy.collider.gameObject.name);
            if (upgradeLevel > 2)
            {
                //Apply stun
                Debug.Log(enemy.collider.gameObject.name + " stunned!");
            }
        }
    }

    //Draws a ray equal to the raycast debugging purposes
    IEnumerator DebugRay()
    {
        yield return new WaitForSeconds(0.8f);
        for (int i = 0; i < 10; i ++)
        {
            Debug.DrawRay(attackPoint.position, attackPoint.up * lightningBoltRange);
            if (upgradeLevel > 1)
            {
                attackPoint.Rotate(new Vector3(0f, 0f, -35f));
                Debug.DrawRay(attackPoint.position, attackPoint.up * lightningBoltRange);
                attackPoint.Rotate(new Vector3(0f, 0f, 70f));
                Debug.DrawRay(attackPoint.position, attackPoint.up * lightningBoltRange);
                attackPoint.Rotate(new Vector3(0f, 0f, -35f));
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
