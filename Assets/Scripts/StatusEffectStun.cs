using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectStun : StatusEffectParent{
    public StatusEffectStun(float duration){
        this.duration = duration;
    }

    public override void Awake(){
        base.Awake();
        duration = 1.0f;
    }

    // Start is called before the first frame update
    void Start(){
        ApplyEffect();
    }

    public override void ApplyEffect(){
        //Suspend player control
        TickEffect();
    }

    public override void ClearEffect(){
        //Return player control
        base.ClearEffect();
    }

    public override IEnumerator TickEffect(){
        return base.TickEffect();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
