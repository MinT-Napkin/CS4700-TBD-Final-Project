using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : Entity, InteractInterface{
    //For HP
    public HealthBarUI healthBar;
    public Canvas canvas;

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

    LayerMask interactableLayer;
    float interactionRange = 2.0f;



    public override void Awake(){
        interactableLayer = LayerMask.GetMask("Interactable");

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

        //MaxHPBar

    }

    public virtual void InteractWithTarget(Entity entity){
        foreach (Collider2D interactable in Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer)){
            Debug.Log("Interacting with " + interactable.name);
            interactable.GetComponent<InteractInterface>().InteractWithTarget(entity);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable")){
            Debug.Log("Press E to interact.");
        }
    }


    void CheckTargets(){

    }

    protected override void DamageHealth(float finalDamage){
        base.DamageHealth(finalDamage);

        healthBar.setCurrentHealth(entityStats.normalizedHealth);
    }

        // Start is called before the first frame update
        void Start(){
            healthBar.setCurrentHealth(entityStats.currentHealth);
        }

    // Update is called once per frame
    void Update(){
        CheckTargets();

        if (Input.GetKeyDown("9")){
            //inventory.GetFromInventory(0).Use();
        }

        //Interaction input
        if (Input.GetKeyDown("e")){
            InteractWithTarget(this);
        }

        if (Input.GetKeyDown("u")){ 
            flamethrower.Upgrade();
            shield.Upgrade();
            lightningBolt.Upgrade();
            doomblades.Upgrade();
        }

        if (Input.GetKeyDown("k")){
            DamageTypeParent damageType = new DamageTypeParent();

            DamageEvent damageEvent = new DamageEvent(10.0f, damageType, this, this, false);

            TakeDamage(damageEvent);

            Debug.Log(entityStats.currentHealth);
        }

        if (Input.GetKeyDown("l")){
            DamageTypeParent damageType = new DamageTypeParent();

            DamageEvent damageEvent = new DamageEvent(-10.0f, damageType, this, this, false);

            TakeDamage(damageEvent);

            Debug.Log(entityStats.currentHealth);
        }

    }

    //Debug doomblades gizmo
    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(meleeAttackPoint.position, 2.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
