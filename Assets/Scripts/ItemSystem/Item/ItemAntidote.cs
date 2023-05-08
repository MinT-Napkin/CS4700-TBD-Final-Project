using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAntidote : ItemParent{
    public TextSystemUI textSystem;

    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "Basic antidote. Cures poison.";
        name = "Antidote";
    }

    public override void Use(Entity entity){
        //Nullifies poison status effect
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
