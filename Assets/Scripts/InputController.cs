using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public PlayerClass playerClass;

    void Awake()
    {
        playerClass = GetComponent<PlayerClass>();
    }

    void Update()
    {
        playerClass.playerMovement.movement.x = Input.GetAxisRaw("Horizontal");
        playerClass.playerMovement.movement.y = Input.GetAxisRaw("Vertical");
        playerClass.playerMovement.run = Input.GetKey("left shift");
    }
}
