using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float activeMoveSpeed;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float dashSpeed = 50f; //Adjusting this in inspector adjusts how far the dash goes
    public Rigidbody2D rb2d;
    Vector2 movement;
    Vector2 dash;
    bool run;
    State state;

    private enum State
    {
        Normal,
        Dashing
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        activeMoveSpeed = walkSpeed;
        state = State.Normal;
    }

    void Update()
    {
        switch (state)
        {
            case State.Normal:
                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");
                run = Input.GetKey("left shift");
                if (Input.GetKeyDown("space"))
                {
                    dash = movement;
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
                    activeMoveSpeed = runSpeed;
                }
                else
                {
                    activeMoveSpeed = walkSpeed;
                }
                rb2d.velocity = movement * activeMoveSpeed;
                break;
            //Dash
            case State.Dashing:
                rb2d.velocity = dash * dashSpeed;
                break;
        }
        //Rotate
        bool right = (movement.x == 1);
        bool left = (movement.x == -1);
        bool up = (movement.y == 1);
        bool down = (movement.y == -1);
        if ((!right) && (!left) && (up) && (!down))
            transform.eulerAngles = Vector3.zero;
        if ((right) && (!left) && (up) && (!down))
            transform.eulerAngles = new Vector3(0, 0, -45);
        if ((right) && (!left) && (!up) && (!down))
            transform.eulerAngles = new Vector3(0, 0, -90f);
        if ((right) && (!left) && (!up) && (down))
            transform.eulerAngles = new Vector3(0, 0, -135);
        if ((!right) && (!left) && (!up) && (down))
            transform.eulerAngles = new Vector3(0, 0, 180);
        if ((!right) && (left) && (up) && (!down))
            transform.eulerAngles = new Vector3(0, 0, 45);
        if ((!right) && (left) && (!up) && (!down))
            transform.eulerAngles = new Vector3(0, 0, 90f);
        if ((!right) && (left) && (!up) && (down))
            transform.eulerAngles = new Vector3(0, 0, 135);
    }

    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(0.1f);
        state = State.Normal;
    }
}
