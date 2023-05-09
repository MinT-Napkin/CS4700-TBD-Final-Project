using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class StatusEffectParent{
    public float duration;
    public Entity entity;
    protected System.Timers.Timer lifetimeTimer;
    public float tickSpeed;
    public bool ticking;
    protected System.Timers.Timer tickTimer;

    public StatusEffectParent(){
    }

    public StatusEffectParent(float duration){
        this.duration = duration;

        SetLifetimeTimer();

        ApplyEffect();
    }

    public StatusEffectParent(Entity entity, float duration){
        this.entity = entity;
        this.duration = duration;

        entity.debuffList.Add(this);

        Debug.Log("Debuff added");

        SetLifetimeTimer();

        if (ticking){
            SetTickTimer();
        }

        ApplyEffect();
    }

    public virtual void SetLifetimeTimer(){
        lifetimeTimer = new System.Timers.Timer(duration * 1000);
        lifetimeTimer.Elapsed += OnLifetimeTimerCompleted;
        lifetimeTimer.AutoReset = false;
    }

    public virtual void SetTickTimer(){
        tickTimer = new System.Timers.Timer(tickSpeed * 1000);
        tickTimer.Elapsed += TickEffect;
        tickTimer.AutoReset = true;
    }

    public virtual void ApplyEffect(){
        lifetimeTimer.Enabled = true;

        if (ticking){
            SetTickTimer();
        }
    }

    public virtual void ClearEffect(){
        lifetimeTimer.Stop();
        tickTimer.Stop();
        lifetimeTimer.Dispose();
        tickTimer.Dispose();

        Debug.Log("Buff removed");

        entity.debuffList.Remove(this);
    }

    protected virtual void OnLifetimeTimerCompleted(System.Object source, ElapsedEventArgs e){
        ClearEffect();
    }

    public virtual void TickEffect(System.Object source, ElapsedEventArgs e){
    }
}