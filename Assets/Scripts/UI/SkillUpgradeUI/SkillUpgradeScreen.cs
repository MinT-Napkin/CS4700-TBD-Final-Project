using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUpgradeScreen : MonoBehaviour
{    
    private GameObject player;
    public GameObject screen;

    public static int flamethrowerUpgrade = 1;
    public static int lightningUpgrade = 1;
    public static int shieldUpgrade = 1;
    public static int doombladeUpgrade = 1;
    public static int skillPoints = 0;

    public TextMeshProUGUI fText;
    public TextMeshProUGUI lText;
    public TextMeshProUGUI sText;
    public TextMeshProUGUI dText;

    public Button fButton;
    public Button lButton;
    public Button sButton;
    public Button dButton;

    public TextMeshProUGUI spText;
    public TextMeshProUGUI info;

    private Flamethrower flamethrower;
    private LightningBolt lightning;
    private Shield shield;
    private Doomblades dm;

    private bool screenOpen;

    private void Start() {
        player = GameObject.Find("Player");
        flamethrower = player.GetComponent<Flamethrower>();
        lightning = player.GetComponent<LightningBolt>();
        shield = player.GetComponent<Shield>();
        dm = player.GetComponent<Doomblades>();
    }
    
    void Update() {

        if (Input.GetKeyDown(KeyCode.J) && !screenOpen)
        {
            screenOpen = true;
            screen.SetActive(true);
            // Pause the game
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.J) && screenOpen) 
        {
            screenOpen = false;
            screen.SetActive(false);
            // Resume the game
            Time.timeScale = 1;
        }

        if(screenOpen)
        {
            spText.text = "Skill Points: " + skillPoints;
            fText.text = "Flamethrower (Tier " + flamethrowerUpgrade + ")";
            lText.text = "Lightning Bolt (Tier " + lightningUpgrade + ")";
            sText.text = "Shield (Tier " + shieldUpgrade + ")";
            dText.text = "Doomblades (Tier " + doombladeUpgrade + ")";
        }
        
    }

    public void UpgradeFlamerthrower()
    {
        switch (flamethrowerUpgrade)
        {
            case 1:
                if(isEnoughSP(5))
                {
                    skillPoints -= 5;
                    flamethrowerUpgrade++;
                    flamethrower.Upgrade();
                }
                break;

            case 2:
                if(isEnoughSP(10))
                {
                    skillPoints -= 10;
                    flamethrowerUpgrade++;
                    flamethrower.Upgrade();
                    fButton.interactable = false;
                }
                break;
            default:

                break;
        }
    }
    public void UpgradeLightning()
    {
        switch (lightningUpgrade)
        {
            case 1:
                if(isEnoughSP(5))
                {
                    skillPoints -= 5;
                    lightningUpgrade++;   
                    lightning.Upgrade();              
                }
                break;

            case 2:
                if(isEnoughSP(10))
                {
                    skillPoints -= 10;
                    lightningUpgrade++;
                    lightning.Upgrade(); 
                    lButton.interactable = false;
                }
                break;
            default:

                break;
        }
    }
    public void UpgradeShield()
    {
        switch (shieldUpgrade)
        {
            case 1:
                if(isEnoughSP(5))
                {
                    skillPoints -= 5;
                    shieldUpgrade++;
                    shield.Upgrade();
                }
                break;

            case 2:
                if(isEnoughSP(10))
                {
                    skillPoints -= 10;
                    shieldUpgrade++;
                    shield.Upgrade();
                    sButton.interactable = false;
                }
                break;
            default:

                break;
        }
    }
    public void UpgradeDoomblades()
    {
        switch (doombladeUpgrade)
        {
            case 1:
                if(isEnoughSP(5))
                {
                    skillPoints -= 5;
                    doombladeUpgrade++;
                    dm.Upgrade();
                }
                break;

            case 2:
                if(isEnoughSP(10))
                {
                    skillPoints -= 10;
                    doombladeUpgrade++;
                    dm.Upgrade();
                    dButton.interactable = false;
                }
                break;
            default:

                break;
        }
    }

    public static void increaseSkillPoints(int num)
    {
        skillPoints += num;
    }

    private bool isEnoughSP(int required)
    {
        return (skillPoints >= required);
    }
}
