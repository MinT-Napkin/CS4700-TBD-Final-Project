using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : ItemParent
{
    public override void Awake()
    {
        base.Awake();
        name = "First Aid Kit";
    }

    public override void Use(){}
}
