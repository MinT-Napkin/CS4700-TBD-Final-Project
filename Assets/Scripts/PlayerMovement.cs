using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float activeMoveSpeed;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float dashSpeed = 50f;
    public Rigidbody2D rb2d;
    public Vector2 movement;
    public Vector2 dash;
    public bool run;
    public State state;

    public enum State
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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKey("left shift"))
            run = true;
        else
            run = false;
        if (Input.GetKeyDown("space"))
        {
            state = State.Dashing;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
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
            case State.Dashing:
                rb2d.velocity = movement * dashSpeed;
                StartCoroutine(DashTimer());
                break;
        }
        
        bool right = (movement.x > 0);
        bool left = (movement.x < 0);
        bool up = (movement.y > 0);
        bool down = (movement.y < 0);
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
