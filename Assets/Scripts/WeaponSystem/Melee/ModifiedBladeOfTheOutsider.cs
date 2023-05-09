using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifiedBladeOfTheOutsider : MeleeWeapon{
    public override void Awake(){
        base.Awake();
        attackDamage = 10.0f;
        attackRange = 1.0f;
        description = "A weapon imroved to match the battle-hardened spirit that wields it";
        name = "Modified Outsider's Blade";
    }

    public override void Equip(){
        base.Equip();
        playerStats.criticalDamage *= 2.0f;
    }
    public override void Unequip(){
        base.Unequip();
        playerStats.criticalDamage /= 2.0f;
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
