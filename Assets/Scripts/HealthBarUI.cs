using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private void Awake(){
        slider.maxValue = 1.0f;
        slider.minValue = 0.0f;
        fill.color = gradient.Evaluate(1.0f);
    }

    public void setCurrentHealth(float currentHealth){
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}
