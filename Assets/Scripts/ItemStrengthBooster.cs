using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStrengthBooster : ItemParent{
    public TextSystemUI textSystem;

    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "This steroid was used in the old wars to enhance supersoldier performance in the field. Raises one's strength to unimaginable levels.";
        name = "Strength Booster";
    }

    public override void Use(Entity entity){
        //Boosts player's strength for a duration
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
