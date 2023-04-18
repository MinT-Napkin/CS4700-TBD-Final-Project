using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    PlayerMovement playerMovement;
    public EntityStats playerStats;

    void Awake(){
        playerMovement = gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
        playerStats = new EntityStats();
        playerMovement.SetEntityStats(playerStats);
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
