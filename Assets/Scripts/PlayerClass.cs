using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    public Transform attackPoint;
    public MeleeWeapon meleeWeapon;
    PlayerMovement playerMovement;
    public EntityStats playerStats;

    void Awake(){
        meleeWeapon = gameObject.AddComponent<BladeOfTheOutsider>() as MeleeWeapon;
        meleeWeapon.attackPoint = attackPoint;
        playerMovement = gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
        playerStats = new EntityStats();
        meleeWeapon.SetEntityStats(playerStats);
        playerMovement.SetEntityStats(playerStats);
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
