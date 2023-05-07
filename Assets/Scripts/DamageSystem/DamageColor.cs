using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageColor {
    private static Dictionary<System.Type, Color> damageColor = new Dictionary<System.Type, Color>();

    public static Color GetColor(DamageTypeParent damageType){
        damageColor.TryAdd(new DamageTypeHealing().GetType(), new Color(0/255f, 255/255f, 108/255f));
        damageColor.TryAdd(new DamageTypeLightning().GetType(), new Color(133/255f, 45/255f, 202/255f));
        damageColor.TryAdd(new DamageTypePhysical().GetType(), new Color(240/255f, 70/255f, 70/255f));
        damageColor.TryAdd(new DamageTypeUnmitigable().GetType(), new Color(175/255f, 175/255f, 175/255f));
        
        return damageColor[damageType.GetType()];
    }
}
