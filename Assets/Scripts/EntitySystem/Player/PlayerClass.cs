using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerClass : Entity, InteractInterface{
    //For HP
    public HealthBarUI healthBar;
    public Canvas canvas;

    public GameObject gangBossResetPrefab;

    public Transform meleeAttackPoint;
    public MeleeWeapon meleeWeapon;
    public PlayerMovement playerMovement;
    public Transform rangedAttackPoint;
    public RangedWeapon rangedWeapon;

    public Transform flamethrowerAttackPoint;

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

    public GameObject inventoryPanel;

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

        // inventoryPanel.GetComponent<Image>().enabled = false;
        // inventoryPanel.GetComponent<InventoryPanel>().player = this;
    }

    protected override void OnEntityDeath(){
        SoundManager.instance.PlaySound(SoundManager.instance.deathSound);
        SceneManager.LoadScene("GameOver");
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("triggered");
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable")){
            Debug.Log("Press E to interact.");
        }
    }

    void CheckTargets(){

    }

    // Start is called before the first frame update
    protected override void Start(){
        base.Start();
        
        healthBar.setCurrentHealth(entityStats.currentHealth);
    }

    // Update is called once per frame
    void Update(){
        CheckTargets();

        if (Input.GetKeyDown("9")){
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
            //SoundManager.instance.PlaySound(SoundManager.instance.healSound);
            DamageTypePhysical damageType = new DamageTypePhysical();

            DamageEvent damageEvent = new DamageEvent(10.0f, damageType, this, this, false);

            TakeDamage(damageEvent);

            Debug.Log(entityStats.currentHealth);
        }

        if (Input.GetKeyDown("y")) {
            if (inventoryPanel.GetComponent<Image>().enabled) {
                inventoryPanel.GetComponent<InventoryPanel>().DestructPanel();
            }
            else {
                inventoryPanel.GetComponent<InventoryPanel>().ConstructPanel();
            }
        }

        if (Input.GetKeyDown("g")){
            LevelUp();
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
        if (flamethrower.upgradeLevel < 2)
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Up;
        else
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Up;
        flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, -90);
    }

    public void SetMeleeAttackPointDownEvent()
    {
        meleeWeapon.attackPoint.localPosition = new Vector2(0, -1.05f);
        rangedWeapon.attackPoint.localPosition = new Vector2(-0.139f, -0.579f);
        if (flamethrower.upgradeLevel < 2)
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Down;
        else
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Down;
        flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, 90);
    }

    public void SetMeleeAttackPointSideEvent()
    {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            meleeWeapon.attackPoint.localPosition = new Vector2(1.05f, 0);
            rangedWeapon.attackPoint.localPosition = new Vector2(0.557f, -0.194f);
            if (flamethrower.upgradeLevel < 2)
                flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Right;
            else
                flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Right;
            flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            meleeWeapon.attackPoint.localPosition = new Vector2(-1.05f, 0);
            rangedWeapon.attackPoint.localPosition = new Vector2(-0.557f, -0.194f);
            if (flamethrower.upgradeLevel < 2)
                flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Left;
            else
                flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Left;
            flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, 0);
        }
    }


    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);
    }
}
