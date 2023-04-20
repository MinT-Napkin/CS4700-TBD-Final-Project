using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour{
    public Transform attackPoint;
    public MeleeWeapon meleeWeapon;
    public EntityStats playerStats;
    public PlayerMovement playerMovement;
    public StatusEffectManager statusEffectManager;
    public List<StatusEffect> activeStatusEffects; //In case we need to check what status effects are currently active
    public List<string> immuneStatusEffects; //In case player can temporarily become immune to a status effect

    void Awake(){
        playerMovement = GetComponent<PlayerMovement>();
        meleeWeapon = gameObject.AddComponent<MetalScrapBat>() as MeleeWeapon;
        meleeWeapon.attackPoint = attackPoint;
        playerStats = new EntityStats();
        statusEffectManager = gameObject.AddComponent<StatusEffectManager>();
        activeStatusEffects = new List<StatusEffect>();
        immuneStatusEffects = new List<string>();
    }
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
    }
}
