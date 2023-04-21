using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    public Transform meleeAttackPoint;
    public MeleeWeapon meleeWeapon;
    PlayerMovement playerMovement;
    public EntityStats playerStats;
    public Transform rangedAttackPoint;
    public RangedWeapon rangedWeapon;
    
    //Testing
    public SpecialAttack specialAttack;

    public GameObject bulletPrefab;

    void Awake(){
        playerStats = new EntityStats();

        meleeWeapon = gameObject.AddComponent<BladeOfTheOutsider>() as MeleeWeapon;
        meleeWeapon.attackPoint = meleeAttackPoint;
        meleeWeapon.SetEntityStats(playerStats);

        playerMovement = gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
        playerMovement.SetEntityStats(playerStats);

        rangedWeapon = gameObject.AddComponent<RangedWeapon>() as RangedWeapon;
        rangedWeapon.attackPoint = rangedAttackPoint;
        rangedWeapon.SetEntityStats(playerStats);
        rangedWeapon.SetPrefab(bulletPrefab);

        //Testing
        specialAttack = gameObject.AddComponent<Flamethrower>() as SpecialAttack;
        specialAttack.gameObject.GetComponent<Flamethrower>().flamethrowerCollider = rangedAttackPoint.gameObject.GetComponent<PolygonCollider2D>();
        specialAttack.attackPoint = rangedAttackPoint;
        specialAttack.SetEntityStats(playerStats);
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
