using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEvent : MonoBehaviour{
    public DamageEvent(){
    }

    public DamageEvent(float baseDamage, DamageTypeParent damageType, Entity damageCauser, Entity damagedEntity){
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.damageCauser = damageCauser;
        this.damagedEntity = damagedEntity;

    }

    public void Initialize(float baseDamage, DamageTypeParent damageType, Entity damageCauser, Entity damagedEntity){ //I hate unity.
        this.baseDamage = baseDamage;
        this.damageType = damageType;
        this.damageCauser = damageCauser;
        this.damagedEntity = damagedEntity;

    }

    public float ApplyDamage(){
        float finalDamage;

        finalDamage = damageType.ApplyDamage(baseDamage, damageCauser, damagedEntity);

        return finalDamage;
    }

    private float baseDamage;
    private DamageTypeParent damageType;
    private Entity damageCauser;
    private Entity damagedEntity;
}
