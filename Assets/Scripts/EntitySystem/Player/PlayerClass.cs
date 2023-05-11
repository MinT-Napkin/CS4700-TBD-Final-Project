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

    //For special attacks
    public Transform flamethrowerAttackPoint;
    public Transform lightningBoltAttackPoint;
    public GameObject shieldPoint;

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

        //inventoryPanel.GetComponent<Image>().enabled = false;
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

        inventoryPanel.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update(){
        CheckTargets();

        if (Input.GetKeyDown("/"))
        {
            gameObject.AddComponent<StatusEffectBurn>().Constructor(this, 5f, true, 0.5f);
        }

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

        if (Input.GetKeyDown("q")){
            if (inventory.GetInventory().Count > 0){
                inventory.GetInventory()[0].Key.Use(this);
                Debug.Log("Used");
            }
            else {
                Debug.Log("No item");
            }
        }

        if (Input.GetKeyDown("y")){
            if (inventoryPanel.GetComponent<Image>().enabled){
                inventoryPanel.GetComponent<InventoryPanel>().DestructPanel();
            }
            else {
                inventoryPanel.GetComponent<InventoryPanel>().ConstructPanel(this);
            }
        }

        if (Input.GetKeyDown("g")){
            LevelUp();
        }
    }

    protected override void DamageHealth(float finalDamage){
        if (!shield.shieldActive)
            base.DamageHealth(finalDamage);
        else
        {
            base.DamageHealth(0);
            if (shield.upgradeLevel < 3)
                shield.Deactivate();
        }

        healthBar.setCurrentHealth(entityStats.normalizedHealth);
    }

    public void InteractWithTarget(Entity entity) {
        foreach (Collider2D interactable in Physics2D.OverlapCircleAll(transform.position, interactionRange, interactableLayer)) {
            Debug.Log("From the Player Class: " + GetInstanceID() + " is interacting with " + interactable.gameObject.GetComponent<ItemParent>().name);
            interactable.GetComponent<InteractInterface>().InteractWithTarget(entity);
        }
    }

    public override void LevelUp(){
        meleeWeapon.Unequip();

        base.LevelUp();

        healthBar.setCurrentHealth(entityStats.currentHealth);

        meleeWeapon.Equip();

        //Set Skill point increase here
        SkillUpgradeScreen.increaseSkillPoints(5);
    }


    public void AttackEvent(){
        meleeWeapon.Attack();
    }

    public void RangedAttackEvent(){
        rangedWeapon.Attack();
    }

    public void SetMeleeAttackPointUpEvent(){
        meleeWeapon.attackPoint.localPosition = new Vector2(0, 1.05f);
        rangedWeapon.attackPoint.localPosition = new Vector2(0.109f, 0.357f);
        if (flamethrower.upgradeLevel < 2)
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Up;
        else
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Up;
        flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, -90);
        lightningBoltAttackPoint.localPosition = new Vector2(-0.0599999987f,4.42999983f);
        lightningBoltAttackPoint.eulerAngles = new Vector3(0, 0, -90);
    }

    public void SetMeleeAttackPointDownEvent(){
        meleeWeapon.attackPoint.localPosition = new Vector2(0, -1.05f);
        rangedWeapon.attackPoint.localPosition = new Vector2(-0.139f, -0.579f);
        if (flamethrower.upgradeLevel < 2)
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Down;
        else
            flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Down;
        flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, 90);
        lightningBoltAttackPoint.localPosition = new Vector2(-0.0599999987f,-4.73999977f);
        lightningBoltAttackPoint.eulerAngles = new Vector3(0, 0 , 90);
    }

    public void SetMeleeAttackPointSideEvent(){
        if (GetComponent<SpriteRenderer>().flipX){
            meleeWeapon.attackPoint.localPosition = new Vector2(1.05f, 0);
            rangedWeapon.attackPoint.localPosition = new Vector2(0.557f, -0.194f);
            if (flamethrower.upgradeLevel < 2)
                flamethrowerAttackPoint.localPosition = flamethrower.upgrade1Right;
            else
                flamethrowerAttackPoint.localPosition = flamethrower.upgrade2Right;
            flamethrowerAttackPoint.eulerAngles = new Vector3(0, 0, 180);
            lightningBoltAttackPoint.localPosition = new Vector2(4.92999983f,-0.430000007f);
            lightningBoltAttackPoint.eulerAngles = new Vector3(0, 0, 180);
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
            lightningBoltAttackPoint.localPosition = new Vector2(-4.71999979f,-0.430000007f);
            lightningBoltAttackPoint.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    public void ShieldHeal()
    {
        DamageHealth(-entityStats.maxHealth * 0.25f);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionRange);

        //doomblades debug
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 2f);
    }
}
