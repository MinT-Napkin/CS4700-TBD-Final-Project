using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StatusEffectBurning : StatusEffectParent{
    public override void ApplyEffect(){
        base.ApplyEffect();
    }

    public override void ClearEffect(){
        base.ClearEffect();
    }

    protected override void TickEffect(){
        DamageTypeFire damageType = new DamageTypeFire();
        DamageEvent damageEvent = new DamageEvent(1.2f, damageType, entity, entity, DamageCategory.Normal);

        entity.TakeDamage(damageEvent);

        Debug.Log("Player took burn damage");
    }
}
