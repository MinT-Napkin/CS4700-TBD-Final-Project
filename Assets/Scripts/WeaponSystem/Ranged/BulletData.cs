using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Bullet Data")]
public class BulletData : ScriptableObject{
    public float bulletStrength;
    public float bulletRange;
    public float bulletSpeed;
}
