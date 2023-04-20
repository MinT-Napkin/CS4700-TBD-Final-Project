using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalScrapBat : MeleeWeapon{
    public override void Awake(){
        base.Awake();
        attackDamage = 15.0f;
        attackRange = 1.0f;     
    }
}
