using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    Rigidbody2D rb2d;
    //public float walkSpeed = 10f;
    //public float runSpeed = 20f;
    //public float dashDistance = 20f;

    public EntityStats playerStats;


    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update(){
        WalkHandler();
        DashHandler();
    }

    public void SetEntityStats(EntityStats playerStats){
        this.playerStats = playerStats;
        Debug.Log("Copy made");
    }

    void WalkHandler(){
        //Walk
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        rb2d.velocity = new Vector2(moveHorizontal * playerStats.walkSpeed, moveVertical * playerStats.walkSpeed);

        //Run
        if (rb2d.velocity.x > 0){
            if (Input.GetKey("left shift")){
                rb2d.velocity = new Vector2(rb2d.velocity.x + (playerStats.runSpeed - playerStats.walkSpeed), rb2d.velocity.y);
            }
        }
        if (rb2d.velocity.x < 0){
            if (Input.GetKey("left shift")){
                rb2d.velocity = new Vector2(rb2d.velocity.x - (playerStats.runSpeed - playerStats.walkSpeed), rb2d.velocity.y);
            }
        }
        if (rb2d.velocity.y > 0){
            if (Input.GetKey("left shift")){
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + (playerStats.runSpeed - playerStats.walkSpeed));
            }
        }
        if (rb2d.velocity.y < 0){
            if (Input.GetKey("left shift")){
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - (playerStats.runSpeed - playerStats.walkSpeed));
            }
        }

        //Rotation change - Character can be turned in 8 directions, faces the direction of walking
        if ((rb2d.velocity.x > 0) && (rb2d.velocity.y == 0)){
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        if ((rb2d.velocity.x < 0) && (rb2d.velocity.y == 0)){
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if ((rb2d.velocity.x == 0) && (rb2d.velocity.y > 0)){
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if ((rb2d.velocity.x == 0) && (rb2d.velocity.y < 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        if ((rb2d.velocity.x > 0) && (rb2d.velocity.y > 0))
        {
            transform.eulerAngles = new Vector3(0, 0, -45);
        }
        if ((rb2d.velocity.x < 0) && (rb2d.velocity.y < 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 135);
        }
        if ((rb2d.velocity.x > 0) && (rb2d.velocity.y < 0))
        {
            transform.eulerAngles = new Vector3(0, 0, -135);
        }
        if ((rb2d.velocity.x < 0) && (rb2d.velocity.y > 0))
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
    }

    //Handles dashing - player dashes in the same direction that they are walking/running
    void DashHandler()
    {
        if (Input.GetKey("space"))
        {
            if (rb2d.velocity.x > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x + playerStats.dashDistance, rb2d.velocity.y);
            }
            if (rb2d.velocity.x < 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x - playerStats.dashDistance, rb2d.velocity.y);
            }
            if (rb2d.velocity.y > 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y + playerStats.dashDistance);
            }
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y - playerStats.dashDistance);
            }
        }
    }
}
