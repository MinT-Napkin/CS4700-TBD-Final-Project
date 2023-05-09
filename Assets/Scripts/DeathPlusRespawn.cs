using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlusRespawn : MonoBehaviour
{
    public PlayerClass player;
    public HealthBarUI healthBar;
    public void Awake()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerClass>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHp();
    }

    public void checkHp()
    {
        if(player.entityStats.normalizedHealth <= 0 || player.entityStats.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        player.transform.position = new Vector3(5.77f, -4.33f, 0f);
        player.entityStats.normalizedHealth = 1;
        player.entityStats.currentHealth = player.entityStats.maxHealth;
        healthBar.setCurrentHealth(player.entityStats.currentHealth);
    }
}
