using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : SpecialAttack
{
    public float shieldDuration;
    public bool shieldActive;

    public override void Awake()
    {
        base.Awake();
        inputKey = "2";
        name = "Shield";
        description = "Shield activated by a device, often used as means of self-preservation by security robots.";
        attackCooldown = 7f;
        shieldDuration = 2f;
        shieldActive = false;
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;
    }

    public override void Update()
    {
        base.Update();
        if (shieldActive)
        {
            //If player is hit, nullify damage
            //For debugging:
            if (Input.GetKeyDown("n"))
            {
                Debug.Log("Damage nullified by shield");
                Deactivate();
            }
        }
    }

    public override void Attack()
    {
        StartCoroutine(Activate());
    }

    public void Deactivate()
    {
        shieldActive = false;
        Debug.Log("Shield deactivated.");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(86f/255f, 241f/255f, 31f/255f);

        if (upgradeLevel > 1)
            playerStats.currentHealth += playerStats.maxHealth * 0.25f;

        base.Attack();
    }

    IEnumerator Activate()
    {
        Debug.Log("Shield activated.");
        shieldActive = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(141f/255f, 9f/255f, 230f/255f);
        yield return new WaitForSeconds(shieldDuration);
        if (shieldActive)
            Deactivate();
    }
}
