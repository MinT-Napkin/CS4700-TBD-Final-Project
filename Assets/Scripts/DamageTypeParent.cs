using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTypeParent{
    protected float finalDamage;
    public virtual float ApplyDamage(float baseDamage, Entity damageCauser, Entity damagedEntity){
        return finalDamage;
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
