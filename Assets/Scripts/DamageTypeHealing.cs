using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypeHealing : DamageTypeParent{
    public override float ApplyDamage(float damageRatio, Entity damageCauser, Entity damagedEntity){
        finalDamage = damageCauser.entityStats.strength * damageRatio;
        finalDamage *= Random.Range(0.8f, 1.2f);

        if (finalDamage < 1){
            finalDamage = 1;
        }

        if ((Random.value * 100) <= damageCauser.entityStats.criticalHitRate)
        {
            finalDamage *= damageCauser.entityStats.criticalDamage;
        }

        finalDamage = Mathf.Round(finalDamage);

        return finalDamage;
    }
}
