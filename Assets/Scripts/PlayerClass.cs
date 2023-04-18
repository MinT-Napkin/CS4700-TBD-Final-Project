using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    PlayerMovement playerMovement;
    public EntityStats playerStats = new EntityStats();

    void Awake(){
        playerMovement = gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
        playerStats.attackSpeed = 1.0f;
        playerStats.currentHealth = 100.0f;
        playerStats.dashDistance = 20.0f;
        playerStats.maxHealth = 100.0f;
        playerStats.normalizedHealth = 1.0f;
        playerStats.runSpeed = 20.0f;
        playerStats.walkSpeed = 10.0f;
        playerMovement.SetEntityStats(playerStats);
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
