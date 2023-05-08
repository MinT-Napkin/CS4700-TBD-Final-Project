using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image abilityImage;
    public string keyInput;
    bool cooldownOn = true;
    public float cooldown;
    public PlayerClass playerClass;


    public virtual void Awake()
    {
        abilityImage.fillAmount = 1;
        playerClass = GameObject.FindWithTag("Player").GetComponent<PlayerClass>();
    }

    public virtual void Update()
    {
        ability();
    }

    public void setCooldown(float c)
    {
        cooldown = c;
    }

    public void ability()
    {
        if (Input.GetKeyDown(keyInput) && cooldownOn == true)
        {
            cooldownOn = false;
            abilityImage.fillAmount = 0;
        }

        if (!cooldownOn)
        {
            abilityImage.fillAmount += 1 / cooldown * Time.deltaTime;
            if (abilityImage.fillAmount >= 1)
            {
                abilityImage.fillAmount = 1;
                cooldownOn = true;
            }
        }
    }

}
