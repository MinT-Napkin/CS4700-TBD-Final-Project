using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        playerMovement.movement = playerInput.actions["Walk"].ReadValue<Vector2>();
        playerMovement.run = playerInput.actions["Run"].ReadValue<float>() == 1;
        if (playerInput.actions["Dash"].ReadValue<float>() == 1)
        {
            playerMovement.dash = playerMovement.movement;
            playerMovement.state = PlayerMovement.State.Dashing;
        }
    }
}
