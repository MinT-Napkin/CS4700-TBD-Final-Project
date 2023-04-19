using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    public Transform attackPoint;
    public MeleeWeapon meleeWeapon;
    public EntityStats playerStats;
    public PlayerMovement playerMovement;

    void Awake(){
        playerMovement = GetComponent<PlayerMovement>();
        meleeWeapon = gameObject.AddComponent<MetalScrapBat>() as MeleeWeapon;
        meleeWeapon.attackPoint = attackPoint;
        playerStats = new EntityStats();
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        Debug.Log(playerMovement.activeMoveSpeed); //debug
    }
}
