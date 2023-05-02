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
        playerClass.GetComponent<PlayerMovement>().movement.x = Input.GetAxisRaw("Horizontal");
        playerClass.GetComponent<PlayerMovement>().movement.y = Input.GetAxisRaw("Vertical");
        playerClass.GetComponent<PlayerMovement>().run = Input.GetKey("left shift");
    }
}
