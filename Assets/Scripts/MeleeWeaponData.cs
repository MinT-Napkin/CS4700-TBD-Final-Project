using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Melee Weapon")]
public class MeleeWeaponData : ScriptableObject
{
   public float attackDamage;
   public float attackRange;
   public float attackCooldown;
}
