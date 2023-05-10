using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypeHealing : DamageTypeParent{
    public override float ApplyDamage(float damageRatio, Entity damageCauser, Entity damagedEntity, DamageCategory damageCategory){
        if (damageCategory == DamageCategory.Normal){
            finalDamage = damageCauser.entityStats.strength * damageRatio;
            finalDamage *= Random.Range(0.8f, 1.2f);

            if (finalDamage < 1.0f){
                finalDamage = 1.0f;
            }

            if ((Random.value * 100) <= damageCauser.entityStats.criticalHitRate){
                finalDamage *= damageCauser.entityStats.criticalDamage;
            }

            finalDamage *= -1.0f;
            finalDamage = Mathf.Round(finalDamage);
        }
        else{
            finalDamage = damageCauser.entityStats.specialAttack * damageRatio;
            finalDamage *= Random.Range(0.8f, 1.2f);

            if (finalDamage < 1.0f){
                finalDamage = 1.0f;
            }

            if ((Random.value * 100) <= damageCauser.entityStats.criticalHitRate){
                finalDamage *= damageCauser.entityStats.criticalDamage;
            }

            finalDamage *= -1.0f;
            finalDamage = Mathf.Round(finalDamage);
        }

        return finalDamage;
    }
}
