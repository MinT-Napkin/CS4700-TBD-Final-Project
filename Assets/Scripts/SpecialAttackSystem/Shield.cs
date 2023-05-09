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
        name = "Shield";
        description = "Shield activated by a device, often used as means of self-preservation by security robots.";
        shieldDuration = 4f;
        attackCooldown = 7f + shieldDuration;
        shieldActive = false;
        //Here, check player data and adjust upgrade level appropriately
        upgradeLevel = 1;

        //Adjust duration and cooldown based on upgrade level here
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
                if (upgradeLevel < 3)
                    Deactivate();
            }
        }
    }

    public override void Upgrade()
    {
        upgradeLevel += 1;
        Debug.Log("Shield upgrade: " + upgradeLevel);
    }

    public override void Attack()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.shieldSound);
        StartCoroutine(Activate());
        base.Attack();
    }

    public void Deactivate()
    {
        shieldActive = false;
        Debug.Log("Shield deactivated.");
        gameObject.GetComponent<SpriteRenderer>().color = new Color(86f/255f, 241f/255f, 31f/255f);

        if (upgradeLevel > 1)
        {
            playerStats.currentHealth += playerStats.maxHealth * 0.25f;
            Debug.Log("Healed the player by 25% of their max health");
        }
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
