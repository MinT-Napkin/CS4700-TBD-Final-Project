using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Ranged Weapon")]
public class RangedWeaponData : ScriptableObject
{
    new public string name;
    public float strength;
    public float attackRange;
    public float attackCooldown;
    public float bulletSpeed;
}
