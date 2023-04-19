using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public Rigidbody2D rb2d;
    Vector2 movement;
    bool run;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        run = Input.GetKey("left shift");
    }

    void FixedUpdate()
    {
        //Move
        float baseWalkSpeed = walkSpeed;
        if (run)
        {
            walkSpeed = runSpeed;
        }
        rb2d.MovePosition(rb2d.position + movement * walkSpeed * Time.fixedDeltaTime);
        walkSpeed = baseWalkSpeed;
        //Rotate
        bool right = Input.GetKey("right");
        bool left = Input.GetKey("left");
        bool up = Input.GetKey("up");
        bool down = Input.GetKey("down");
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
}
