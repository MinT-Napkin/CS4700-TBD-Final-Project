using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour{
    public Slider slider;

    private void Awake(){
        slider.maxValue = 1.0f;
        slider.minValue = 0.0f;
    }

    public void setCurrentHealth(float currentHealth){
        slider.value = currentHealth;
    }

}
