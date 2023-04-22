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
    public SpecialAttack[] specialAttacks;
    public Flamethrower flamethrower;

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
        specialAttacks = new SpecialAttack[5];
        specialAttacks[0] = flamethrower;

        flamethrower = gameObject.AddComponent<Flamethrower>();
        flamethrower.gameObject.GetComponent<Flamethrower>().flamethrowerCollider = rangedAttackPoint.gameObject.GetComponent<PolygonCollider2D>();
        flamethrower.attackPoint = rangedAttackPoint;
        flamethrower.SetEntityStats(playerStats);
        flamethrower = flamethrower.gameObject.GetComponent<Flamethrower>();
    }

    //Testing level 2 upgrade
    void UpgradeFlamethrower()
    {
        flamethrower.upgradeLevel += 1;
        if (flamethrower.upgradeLevel == 2)
        {
            flamethrower.flamethrowerDuration += 3f;
            flamethrower.attackCooldown += 3f;
            Vector2 upgrade2Point1 = new Vector2(flamethrower.flamethrowerCollider.points[0].x -= 1, flamethrower.flamethrowerCollider.points[0].y += 1);
            Vector2 upgrade2Point2 = new Vector2(flamethrower.flamethrowerCollider.points[1].x += 1, flamethrower.flamethrowerCollider.points[1].y += 1);
            Vector2[] upgradeLevel2Points = {upgrade2Point1, upgrade2Point2, flamethrower.flamethrowerCollider.points[2]};
            flamethrower.flamethrowerCollider.SetPath(0, upgradeLevel2Points);
        }
        Debug.Log("Flamethrower upgrade: " + flamethrower.upgradeLevel);
    }

    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown("u")) //To see the upgrade in action and test differences
            UpgradeFlamethrower();
    }
}
