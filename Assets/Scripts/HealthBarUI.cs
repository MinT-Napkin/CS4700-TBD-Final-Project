using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarUI : MonoBehaviour
{
    public Slider slider;

    private void Awake()
    {

    }
    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
    }
    public void setCurrentHealth(float health)
    {
        slider.value = health;
    }

}
