using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StatusEffectParent : MonoBehaviour{
    protected float duration;
    protected Entity entity;
    protected bool ticking;
    protected float tickSpeed;

    public virtual void Constructor(Entity entity, float duration){
        this.entity = entity;
        this.duration = duration;

        ticking = false;
        tickSpeed = 0.0f;

        StartCoroutine(StatusEffectLifetime());
    }

    public virtual void Constructor(Entity entity, float duration, bool ticking, float tickSpeed) {
        this.entity = entity;
        this.duration = duration;
        this.ticking = ticking;
        this.tickSpeed = tickSpeed;

        StartCoroutine(StatusEffectLifetime());

        if (ticking){
            InvokeRepeating("TickEffect", tickSpeed, tickSpeed);
        }
    }

    public virtual void ApplyEffect(){
    }

    public virtual void ClearEffect(){
        Debug.Log("Debuff removed");

        Destroy(this);
    }

    protected virtual IEnumerator StatusEffectLifetime(){
        ApplyEffect();

        yield return new WaitForSeconds(duration);

        ClearEffect();
    }

    protected virtual void TickEffect(){
    }
}