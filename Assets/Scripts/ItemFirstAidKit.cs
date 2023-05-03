using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFirstAidKit : ItemParent{
    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Why do robots need this?";
        name = "First Aid Kit";
    }

    public override void Use(Entity entity){
        DamageEvent damageEvent;
        DamageTypeHealing damageType = new DamageTypeHealing();

        damageEvent = new DamageEvent(-10.0f, damageType, entity, entity, false);

        entity.TakeDamage(damageEvent);

        entity.inventory.RemoveFromInventory(this, 1);
    }
}
