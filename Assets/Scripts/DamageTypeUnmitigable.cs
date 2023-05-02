using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypeUnmitigable : DamageTypeParent{
    public override float ApplyDamage(float damageRatio, Entity damageCauser, Entity damagedEntity){
        if (damageCauser.entityStats.strength > damageCauser.entityStats.specialAttack){
            finalDamage = damageCauser.entityStats.strength * damageRatio;
        }
        else{
            finalDamage = damageCauser.entityStats.specialAttack * damageRatio;
        }

        return finalDamage;
    }
}
