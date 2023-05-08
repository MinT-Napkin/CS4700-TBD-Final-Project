using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearOfThePoliceRobot : MeleeWeapon {
    public override void Awake() {
        base.Awake();
        attackDamage = 15.0f;
        attackRange = 1.5f;
        description = "Stop Resisting";
        name = "Police Robot's Spear";
    }

    public override void Equip() {
        base.Equip();
    }
    public override void Unequip() {
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
