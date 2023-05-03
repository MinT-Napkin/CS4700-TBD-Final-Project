using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypeParent{
    protected float finalDamage;
    public virtual float ApplyDamage(float damageRatio, Entity damageCauser, Entity damagedEntity, DamageCategory damageCategory){
        return finalDamage;
    }

    public virtual float ApplySkillDamage(float damageRatio, Entity damageCauser, Entity damagedEntity)
    {
        return finalDamage;
    }

    public virtual float ApplyUnmitigableDamage(float finalDamage){
        this.finalDamage = finalDamage;

        return finalDamage;
    }
}
