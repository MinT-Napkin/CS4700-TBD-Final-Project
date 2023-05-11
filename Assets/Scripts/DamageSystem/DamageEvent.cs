using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent{
    public DamageEvent(){
    }

    public DamageEvent(float damageRatio, DamageTypeParent damageType, Entity damageCauser, Entity damagedEntity, DamageCategory damageCategory){
        this.damageRatio = damageRatio;
        this.damageType = damageType;
        this.damageCategory = damageCategory;
        this.damageCauser = damageCauser;
        this.damagedEntity = damagedEntity;

        mitigable = true;
    }

    public DamageEvent(float damageRatio, DamageTypeParent damageType, Entity damageCauser, Entity damagedEntity, bool mitigable) {
        this.damageRatio = damageRatio;
        this.damageType = damageType;
        this.damageCauser = damageCauser;
        this.damagedEntity = damagedEntity;
        this.mitigable = mitigable;
    }

    public float ApplyDamage(){
        float finalDamage;

        if (mitigable){
            finalDamage = damageType.ApplyDamage(damageRatio, damageCauser, damagedEntity, damageCategory);
        }
        else{
            finalDamage = damageType.ApplyUnmitigableDamage(damageRatio);
        }

        return finalDamage;
    }

    public Color GetColor()
    {
        return DamageColor.GetColor(damageType);
    }

    private float damageRatio;
    private DamageTypeParent damageType;
    private DamageCategory damageCategory;
    private Entity damageCauser;
    private Entity damagedEntity;
    private bool mitigable;
}
