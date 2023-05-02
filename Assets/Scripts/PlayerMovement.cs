using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float activeMoveSpeed;
    public Rigidbody2D rb2d;
    public PlayerClass playerClass;
    public Vector2 movement;
    public bool run;
    State state;

    private enum State{
        Normal,
        Dashing
    }

    void Awake(){

        playerClass = GetComponent<PlayerClass>();
        rb2d = GetComponent<Rigidbody2D>();
        state = State.Normal;
    }

    void Update(){
        activeMoveSpeed = playerClass.entityStats.walkSpeed;

        switch (state)
        {
            case State.Normal:
                if (Input.GetKeyDown("space"))
                {
                    state = State.Dashing;
                }
                break;
            case State.Dashing:
                StartCoroutine(DashTimer());
                break;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            //Move
            case State.Normal:
                if (run)
                {
                    activeMoveSpeed = playerClass.entityStats.runSpeed;
                }
                else
                {
                    activeMoveSpeed = playerClass.entityStats.walkSpeed;
                }
                rb2d.velocity = movement * activeMoveSpeed;
                break;
            //Dash
            case State.Dashing:
                rb2d.velocity = movement * playerClass.entityStats.dashDistance;
                break;
        }
        //Rotate
        if ((movement.x == 0) || (movement.y == 0))
            RotatePlayer();
    }

    void RotatePlayer()
    {
        if (movement.x == -1)
            transform.eulerAngles = new Vector3(0, 0, 90f);
        else if (movement.x == 1)
            transform.eulerAngles = new Vector3(0, 0, -90f);
        else if (movement.y == -1)
            transform.eulerAngles = new Vector3(0, 0, 180f);
        else if (movement.y == 1)
            transform.eulerAngles = new Vector3(0, 0, 0);
    }

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(0.1f);
        state = State.Normal;
    }
}
