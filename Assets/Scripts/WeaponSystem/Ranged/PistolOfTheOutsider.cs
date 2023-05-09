using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PistolOfTheOutsider : RangedWeapon{
    public override void Awake() {
        base.Awake();
        //attackDamage = 10.0f;
        //attackRange = 1.0f;
        //damageType = new DamageTypePhysical();
        description = "This is the favored blade of one who does not belong to this world";
        name = "Outsider's Blade";
    }

    public override void Equip() {
        base.Equip();
    }
    public override void Unequip() {
        base.Unequip();
    }
}
