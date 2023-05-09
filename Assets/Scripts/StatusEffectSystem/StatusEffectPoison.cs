using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class StatusEffectPoison : StatusEffectParent{
    public override void ApplyEffect() {
        entity.entityStats.defense *= 0.8f;
        entity.entityStats.specialDefense *= 0.8f;
    }

    public override void ClearEffect() {
        entity.entityStats.defense /= 0.8f;
        entity.entityStats.specialDefense /= 0.8f;

        base.ClearEffect();
    }

    protected override void TickEffect() {
        DamageTypePoison damageType = new DamageTypePoison();
        DamageEvent damageEvent = new DamageEvent(1.2f, damageType, entity, entity, DamageCategory.Normal);

        entity.TakeDamage(damageEvent);
    }
}
