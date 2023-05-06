using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLightningBooster : ItemParent{
    public TextSystemUI textSystem;

    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Unknown electronic device. Upon closer examination, it seems to amplify the output of nearby electricity sources.";
        name = "Lightning Booster";
    }

    public override void Use(Entity entity){
        //Boosts player's lightning attack for a duration
    }

    public override void InteractWithTarget(Entity entity)
    {
        base.InteractWithTarget(entity);
        if (Input.GetKey("e"))
        {
            textSystem.enableText();

            textSystem.setTextIn(name + " added to inventory.");

            Destroy(gameObject);
        }




    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        textSystem.disableText();
        Destroy(gameObject);



    }
}
