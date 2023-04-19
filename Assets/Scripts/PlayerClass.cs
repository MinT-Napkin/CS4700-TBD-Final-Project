using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    public Transform attackPoint;
    public MeleeWeapon meleeWeapon;
    public EntityStats playerStats;

    void Awake(){
        meleeWeapon = gameObject.AddComponent<MetalScrapBat>() as MeleeWeapon;
        meleeWeapon.attackPoint = attackPoint;
        playerStats = new EntityStats();
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
