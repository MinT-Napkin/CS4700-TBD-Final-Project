using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageColor {
    private static Dictionary<DamageTypeParent, Color> damageColor = new Dictionary<DamageTypeParent, Color>();

    public static Color GetColor(DamageTypeParent damageType){
        Color color;
        damageColor.Add(new DamageTypeHealing(), new Color(0, 255, 108));
        damageColor.Add(new DamageTypeLightning(), new Color(133, 45, 202));
        damageColor.Add(new DamageTypePhysical(), new Color(225, 225, 225));
        damageColor.Add(new DamageTypeUnmitigable(), new Color(175, 175, 175));

        damageColor.TryGetValue(damageType, out color);

        return color;
    }
}
