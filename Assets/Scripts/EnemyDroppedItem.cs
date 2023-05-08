using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct EnemyDroppedItem
{
    public GameObject item;
    public float dropRate;
    public int maxDropCount;
}
