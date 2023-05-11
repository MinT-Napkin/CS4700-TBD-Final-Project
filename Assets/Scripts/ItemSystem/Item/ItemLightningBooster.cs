using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLightningBooster : ItemParent{
    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Unknown electronic device. Upon closer examination, it seems to amplify the output of nearby electricity sources.";
        name = "Lightning Booster";
    }

    public override void Use(Entity entity){
        //Boosts player's lightning attack for a duration
    }
}
