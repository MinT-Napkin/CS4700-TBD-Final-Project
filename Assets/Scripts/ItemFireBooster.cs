using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFireBooster : ItemParent{
    public TextSystemUI textSystem;

    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Small cannister filled with very highly flammable fuel. Perhaps it can be used to make a flamethrower even more deadly.";
        name = "Fire Booster";
    }

    public override void Use(Entity entity){
        //Boosts player's fire attack for a duration
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
