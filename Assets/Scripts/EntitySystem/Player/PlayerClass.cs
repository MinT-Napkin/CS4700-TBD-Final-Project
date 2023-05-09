using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class PlayerClass : Entity, InteractInterface{
    //For HP
    public HealthBarUI healthBar;
    public Canvas canvas;

    public Transform meleeAttackPoint;
    public MeleeWeapon meleeWeapon;
    public PlayerMovement playerMovement;
    public Transform rangedAttackPoint;
    public RangedWeapon rangedWeapon;

    public Color color;
    
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

        this.entityStats.walkSpeed = 10.0f;
        playerMovement = GetComponent<PlayerMovement>();

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

        isPlayerControlled = true;
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

    // Start is called before the first frame update
    void Start(){
        CSV csv = new CSV(textAsset);

        csv.ReadEntityStats(this);
        
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
            SoundManager.instance.PlaySound(SoundManager.instance.pickUpSound);
            InteractWithTarget(this);
        }

        if (Input.GetKeyDown("u")){ 
            SoundManager.instance.PlaySound(SoundManager.instance.upgradeSound);
            flamethrower.Upgrade();
            shield.Upgrade();
            lightningBolt.Upgrade();
            doomblades.Upgrade();
        }

        if (Input.GetKeyDown("k")){
            DamageTypePhysical damageType = new DamageTypePhysical();

            DamageEvent damageEvent = new DamageEvent(10.0f, damageType, this, this, false);

            TakeDamage(damageEvent);

            Debug.Log(entityStats.currentHealth);
        }

        if (Input.GetKeyDown("l")){
            DamageTypeHealing damageType = new DamageTypeHealing();

            DamageEvent damageEvent = new DamageEvent(-10.0f, damageType, this, this, false);

            TakeDamage(damageEvent);

            Debug.Log(entityStats.currentHealth);
        }

        if (Input.GetKeyDown("=")){
        }

        if (Input.GetKeyDown("g")){
            SoundManager.instance.PlaySound(SoundManager.instance.levelUpSound);
            LevelUp();
        }

        if (Input.GetKeyDown(";"))
        {
            GetComponent<InputController>().EnableInput(false);
        }
    }

    protected override void DamageHealth(float finalDamage){
        base.DamageHealth(finalDamage);

        healthBar.setCurrentHealth(entityStats.normalizedHealth);
    }

    public virtual void InteractWithTarget(Entity entity) {
        foreach (Collider2D interactable in Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer)) {
            Debug.Log("Interacting with " + interactable.name);
            interactable.GetComponent<InteractInterface>().InteractWithTarget(entity);
        }
    }

    public override void LevelUp(){
        meleeWeapon.Unequip();

        base.LevelUp();

        healthBar.setCurrentHealth(entityStats.currentHealth);

        meleeWeapon.Equip();
    }


    public void AttackEvent()
    {
        meleeWeapon.Attack();
    }

    public void RangedAttackEvent()
    {
        rangedWeapon.Attack();
    }

    public void SetMeleeAttackPointUpEvent()
    {
        meleeWeapon.attackPoint.localPosition = new Vector2(0, 1.05f);
        rangedWeapon.attackPoint.localPosition = new Vector2(0.109f, 0.357f);
    }

    public void SetMeleeAttackPointDownEvent()
    {
        meleeWeapon.attackPoint.localPosition = new Vector2(0, -1.05f);
        rangedWeapon.attackPoint.localPosition = new Vector2(-0.139f, -0.579f);
    }

    public void SetMeleeAttackPointSideEvent()
    {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            meleeWeapon.attackPoint.localPosition = new Vector2(1.05f, 0);
            rangedWeapon.attackPoint.localPosition = new Vector2(0.557f, -0.194f);
        }
        else
        {
            meleeWeapon.attackPoint.localPosition = new Vector2(-1.05f, 0);
            rangedWeapon.attackPoint.localPosition = new Vector2(-0.557f, -0.194f);
        }
    }


    //Debug doomblades gizmo
    void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
