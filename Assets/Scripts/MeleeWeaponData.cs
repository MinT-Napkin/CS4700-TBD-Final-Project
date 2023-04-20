using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Melee Weapon")]
public class MeleeWeaponData : ScriptableObject
{
    new public string name;
    public float strength;
    public float attackRange;
    public float attackCooldown;
    public bool inInventory;
}
