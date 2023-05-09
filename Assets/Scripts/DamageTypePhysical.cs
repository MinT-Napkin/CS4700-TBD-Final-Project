using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypePhysical : DamageTypeParent{
    public override float ApplyDamage(float damageRatio, Entity damageCauser, Entity damagedEntity){
        finalDamage = damageCauser.entityStats.strength * damageRatio;
        finalDamage -= (damagedEntity.entityStats.defense / 2.0f);
        finalDamage *= Random.Range(0.8f, 1.2f);

        if (finalDamage < 1) {
            finalDamage = 1.0f;
        }

        if ((Random.value * 100) <= damageCauser.entityStats.criticalHitRate){
            finalDamage *= damageCauser.entityStats.criticalDamage;
        }

        finalDamage = Mathf.Round(finalDamage);

        return finalDamage;
    }
}