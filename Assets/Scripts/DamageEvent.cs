using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent{
    public DamageEvent(){
    }

    public DamageEvent(float baseDamage, DamageTypeParent damageType, Entity damageCauser, Entity damagedEntity){
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.damageCauser = damageCauser;
        this.damagedEntity = damagedEntity;

        mitigable = true;
    }

    public DamageEvent(float baseDamage, DamageTypeParent damageType, Entity damageCauser, Entity damagedEntity, bool mitigable) {
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.damageCauser = damageCauser;
        this.damagedEntity = damagedEntity;
        this.mitigable = mitigable;
    }

    public float ApplyDamage(){
        float finalDamage;

        if (mitigable){
            finalDamage = damageType.ApplyDamage(baseDamage, damageCauser, damagedEntity);
        }
        else{
            finalDamage = damageType.ApplyUnmitigableDamage(baseDamage);
        }

        return finalDamage;
    }

    private float baseDamage;
    private DamageTypeParent damageType;
    private Entity damageCauser;
    private Entity damagedEntity;
    private bool mitigable;
}
