using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StatusEffectBurn : StatusEffectParent{
    public override void ApplyEffect(){
        entity.entityStats.strength *= 0.8f;
        entity.entityStats.specialAttack *= 0.8f;
    }

    public override void ClearEffect(){
        entity.entityStats.strength /= 0.8f;
        entity.entityStats.specialAttack /= 0.8f;

        base.ClearEffect();
    }

    protected override void TickEffect(){
        DamageTypeFire damageType = new DamageTypeFire();
        DamageEvent damageEvent = new DamageEvent(0.1f, damageType, entity, entity, DamageCategory.Normal);

        entity.TakeDamage(damageEvent);
    }
}
