using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StatusEffectBurning : StatusEffectParent{
    public StatusEffectBurning(float duration) : base(duration){
        ticking = true;
        tickSpeed = 0.5f;
    }

    public StatusEffectBurning(Entity entity, float duration) : base(entity, duration){
        ticking = true;
        tickSpeed = 0.5f;
    }

    public override void ApplyEffect(){
        base.ApplyEffect();

        Debug.Log("Player is burning");
    }

    public override void ClearEffect(){

        Debug.Log("Player is no longer burning");

        base.ClearEffect();
    }

    public override void TickEffect(System.Object source, ElapsedEventArgs e){
        DamageTypeFire damageType = new DamageTypeFire();
        DamageEvent damageEvent = new DamageEvent(1.2f, damageType, entity, entity, DamageCategory.Normal);

        entity.TakeDamage(damageEvent);

        Debug.Log("Player took burn damage");
    }
}
