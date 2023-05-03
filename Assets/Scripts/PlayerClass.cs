using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : Entity, InteractInterface{
    //For HP
    public HealthBarUI healthBar;
    public Canvas canvas;

    public Transform meleeAttackPoint;
    public MeleeWeapon meleeWeapon;
    public PlayerMovement playerMovement;
    public Transform rangedAttackPoint;
    public RangedWeapon rangedWeapon;
    public TextAsset textAsset;
    
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
        base.Awake();
        interactableLayer = LayerMask.GetMask("Interactable");

        meleeWeapon = gameObject.AddComponent<BladeOfTheOutsider>() as MeleeWeapon;
        meleeWeapon.attackPoint = meleeAttackPoint;
        meleeWeapon.SetEntityStats(entityStats);

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

    public void start(){
        entityStats.dashDistance = 20.0f;
        entityStats.runSpeed = 15.0f;
        entityStats.walkSpeed = 10.0f;
    }

    public virtual void InteractWithTarget(Entity entity){
        foreach (Collider2D interactable in Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer)){
            Debug.Log("Interacting with " + interactable.name);
            interactable.GetComponent<InteractInterface>().InteractWithTarget(entity);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("triggered");
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable")){
            Debug.Log("Press E to interact.");
        }

        if (other.gameObject.tag == "EnemyBullet")
        {
            Debug.Log("Player hit by enemy bullet!");
            Destroy(other.gameObject);
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
            inventory.GetTest().Use(this);
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

        if (Input.GetKeyDown("f")){
            CSV csv = new CSV(textAsset);

            csv.ReadEntityStats(this);
        }

    }

    //Debug doomblades gizmo
    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(meleeAttackPoint.position, 2.5f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
