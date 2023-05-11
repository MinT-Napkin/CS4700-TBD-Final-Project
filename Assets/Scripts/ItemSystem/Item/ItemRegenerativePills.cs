using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegenerativePills : ItemParent{
    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Potent medicine, used in the past to help all kinds of injuries heal quicker. Ever since robots and cyborgs overtook society, medicine like this have not been needed.";
        name = "Regenerative Pills";
    }

    public override void Use(Entity entity){
        //Gives player a regen status effect for a duration
    }
}
