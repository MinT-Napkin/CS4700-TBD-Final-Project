using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageColor {
    private static Dictionary<System.Type, Color> damageColor = new Dictionary<System.Type, Color>();

    public static Color GetColor(DamageTypeParent damageType){
        damageColor.TryAdd(new DamageTypeHealing().GetType(), new Color(0, 255, 108));
        damageColor.TryAdd(new DamageTypeLightning().GetType(), new Color(133, 45, 202));
        damageColor.TryAdd(new DamageTypePhysical().GetType(), new Color(225, 225, 225));
        damageColor.TryAdd(new DamageTypeUnmitigable().GetType(), new Color(175, 175, 175));
        
        return damageColor[damageType.GetType()];
    }
}
