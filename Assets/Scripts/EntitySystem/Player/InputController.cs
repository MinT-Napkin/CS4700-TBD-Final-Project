using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerClass playerClass;
    public bool inputEnabled = true;
    public bool dashEnabled = true;

    void Awake()
    {
        playerClass = GetComponent<PlayerClass>();
    }

    void Update()
    {
        if (inputEnabled)
        {
            playerClass.GetComponent<PlayerMovement>().movement.x = Input.GetAxisRaw("Horizontal");
            playerClass.GetComponent<PlayerMovement>().movement.y = Input.GetAxisRaw("Vertical");
            playerClass.GetComponent<PlayerMovement>().run = Input.GetKey("left shift");

            if (dashEnabled)
            {
                playerClass.GetComponent<PlayerMovement>().dash = Input.GetKeyDown("space");
            }

            playerClass.meleeWeapon.input = Input.GetKeyDown(playerClass.meleeWeapon.inputKey);
            playerClass.rangedWeapon.input = Input.GetKeyDown(playerClass.rangedWeapon.inputKey);

            playerClass.flamethrower.input = Input.GetKeyDown("1");
            playerClass.lightningBolt.input = Input.GetKeyDown("3");
            playerClass.shield.input = Input.GetKeyDown("2");
            playerClass.doomblades.input = Input.GetKeyDown("4");
        }
    }

    public void EnableInput(bool enable)
    {
        inputEnabled = enable;
    }

    public void EnableDash(bool enable)
    {
        dashEnabled = enable;
    }
}
