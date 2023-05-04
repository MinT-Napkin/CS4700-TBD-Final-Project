using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStrengthBooster : ItemParent{
    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "This steroid was used in the old wars to enhance supersoldier performance in the field. Raises one's strength to unimaginable levels.";
        name = "Strength Booster";
    }

    public override void Use(Entity entity){
        //Boosts player's strength for a duration
    }
}
