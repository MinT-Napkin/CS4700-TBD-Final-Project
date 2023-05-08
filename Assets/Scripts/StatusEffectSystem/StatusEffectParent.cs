using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectParent : MonoBehaviour{
    public float duration;

    public StatusEffectParent() {
    }

    public StatusEffectParent(float duration){
        this.duration = duration;
    }

    public virtual void Awake(){
    }

    public virtual void ApplyEffect(){
    }

    public virtual void ClearEffect(){
        Destroy(this);
    }

    public virtual IEnumerator TickEffect(){
        yield return new WaitForSeconds(duration);
    }
}