using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeOfTheOutsider : MeleeWeapon{
    public override void Awake(){
        base.Awake();
        attackDamage = 10.0f;
        attackRange = 1.0f;
        damageType = gameObject.AddComponent<DamageTypePhysical>();
        description = "This is the favored blade of one who does not belong to this world";
        name = "Outsider's Blade";
    }

    public override void Equip(){
        base.Equip();
    }
    public override void Unequip(){
        base.Unequip();
    }
    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
