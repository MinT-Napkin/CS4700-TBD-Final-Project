using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDefenseBooster : ItemParent{
    public TextSystemUI textSystem;

    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "A steroid variant used to enhance human endurance, back in the times when most of them still had organic bodies.";
        name = "Defense Booster";
    }

    public override void Use(Entity entity){
        //Boosts player's defense for a duration
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
