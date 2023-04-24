using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : Entity{
    public Transform meleeAttackPoint;
    public MeleeWeapon meleeWeapon;
    PlayerMovement playerMovement;
    public Transform rangedAttackPoint;
    public RangedWeapon rangedWeapon;
    
    //Testing special attacks
    public SpecialAttack[] specialAttacks;
    public Flamethrower flamethrower;
    public Shield shield;
    public LightningBolt lightningBolt;
    public Doomblades doomblades;

    public GameObject bulletPrefab;

    void Awake(){
        meleeWeapon = gameObject.AddComponent<BladeOfTheOutsider>() as MeleeWeapon;
        meleeWeapon.attackPoint = meleeAttackPoint;
        meleeWeapon.SetEntityStats(entityStats);

        playerMovement = gameObject.AddComponent<PlayerMovement>() as PlayerMovement;
        playerMovement.SetEntityStats(entityStats);

        rangedWeapon = gameObject.AddComponent<RangedWeapon>() as RangedWeapon;
        rangedWeapon.attackPoint = rangedAttackPoint;
        rangedWeapon.SetEntityStats(entityStats);
        rangedWeapon.SetPrefab(bulletPrefab);

        //Testing special attacks
        specialAttacks = new SpecialAttack[5];
        specialAttacks[0] = flamethrower;
        specialAttacks[1] = shield;
        specialAttacks[2] = lightningBolt;
        specialAttacks[3] = doomblades;

        //Testing flamethrower
        flamethrower = gameObject.AddComponent<Flamethrower>();

        //Testing shield
        shield = gameObject.AddComponent<Shield>();

        //Testing lightning bolt
        lightningBolt = gameObject.AddComponent<LightningBolt>();

        //Testing doomblades
        doomblades = gameObject.AddComponent<Doomblades>();
    }

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("u")){ 
            flamethrower.Upgrade();
            shield.Upgrade();
            lightningBolt.Upgrade();
            doomblades.Upgrade();
        }
    }

    //Debug doomblades gizmo
    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(meleeAttackPoint.position, 2.5f);
    }
}
