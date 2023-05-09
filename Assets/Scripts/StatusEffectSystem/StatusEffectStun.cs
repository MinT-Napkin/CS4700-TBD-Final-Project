using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectStun : StatusEffectParent{
    public override void ApplyEffect(){
        if (entity.isPlayerControlled){
            //inputController = entity.GetComponent<InputController>();
            //inputController.enable
            entity.GetComponent<InputController>().inputEnabled = false;
        }
        else{
        }

        Debug.Log("Player is Stunned");
    }

    public override void ClearEffect(){
        entity.GetComponent<InputController>().inputEnabled = true;

        Debug.Log("Player is no longer Stunned");

        base.ClearEffect();
    }
}