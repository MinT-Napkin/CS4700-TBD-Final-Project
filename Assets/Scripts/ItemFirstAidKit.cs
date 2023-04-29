using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFirstAidKit : ItemParent{
    public override void Awake(){
        base.Awake();
        category = ItemCategories.Consumable;
        description = "A healing kit";
        name = "First Aid Kit";
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Use(Entity entity){
        DamageEvent damageEvent;
        DamageTypeHealing damageType = new DamageTypeHealing();

        damageEvent = new DamageEvent(-10.0f, damageType, entity, entity, false);

        entity.TakeDamage(damageEvent);

        Debug.Log("Used first aid kit");
        Debug.Log("Healed " + 10.0f);
    }
}
