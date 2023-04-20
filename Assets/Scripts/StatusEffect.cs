using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect
{
    public string _name;
    public float duration;
    public float healthTickTime;
    public float healthDifference;
    public bool stun;
    public bool active;

    public StatusEffect(string _name, float duration, float healthTickTime, float healthDifference, bool stun)
    {
        this._name = _name;
        this.duration = duration;
        this.healthTickTime = healthTickTime;
        this.healthDifference = healthDifference;
        this.stun = stun;
        active = false;
    }
}
