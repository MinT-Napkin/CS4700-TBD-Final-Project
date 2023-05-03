using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAntidote : ItemParent{
    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Basic antidote. Cures poison.";
        name = "Antidote";
    }

    public override void Use(Entity entity){
        //Nullifies poison status effect
    }
}
