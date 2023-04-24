using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypePhysical : DamageTypeParent{
    public override float ApplyDamage(float baseDamage, Entity damageCauser, Entity damagedEntity){
        finalDamage = damageCauser.entityStats.strength * baseDamage;
        finalDamage -= (damagedEntity.entityStats.defense / 2.0f);
        finalDamage *= Random.Range(0.8f, 1.2f);

        if (finalDamage < 1) {
            finalDamage = 1;
        }

        if ((Random.value * 100) <= damageCauser.entityStats.criticalHitRate){
            finalDamage *= damageCauser.entityStats.criticalDamage;
        }

        finalDamage = Mathf.Round(finalDamage);

        return finalDamage;
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
