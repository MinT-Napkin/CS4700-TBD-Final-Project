using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public enum SaveInputs
{
    Up,
    Down,
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour
{
    public float activeMoveSpeed;
    public Rigidbody2D rb2d;
    public PlayerClass playerClass;
    public Vector2 movement;
    public bool run;
    public bool dash;
    public bool isShooting;
    public bool isMelee;
    public bool isDash;
    public bool animLock = false;
    public SaveInputs saveInputs = SaveInputs.Down;

    State state;

    private bool idleUp, idleDown, idleSide;
    private Animator animator;
    private bool isFacingRight;
    private bool sideMovement;
    private bool upMovement;
    private bool downMovement;
    private SpriteRenderer sprite;

    private enum State
    {
        Normal,
        Dashing
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerClass = GetComponent<PlayerClass>();
        rb2d = GetComponent<Rigidbody2D>();
        playerClass.entityStats.walkSpeed = activeMoveSpeed;
        sprite = GetComponent<SpriteRenderer>();
        state = State.Normal;
    }

    void Update(){
        activeMoveSpeed = playerClass.entityStats.walkSpeed;

        switch (state)
        {
            case State.Normal:
                if (dashInput)
                {
                    state = State.Dashing;
                }
                break;
            case State.Dashing:
                StartCoroutine(DashTimer());
                break;
        }
        CheckMovement();
        if (!animLock) UpdateAnimation();
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
                SoundManager.instance.PlaySound(SoundManager.instance.dashSound);
                rb2d.velocity = movement * playerClass.entityStats.dashDistance * 2f;
                break;
        }

    }

    void CheckMovement()
    {
        //Debug.Log($"{saveInputs}");
        if (movement.x < 0)
        {
            sprite.flipX = false;
            saveInputs = SaveInputs.Right;
        }
        else if (movement.x > 0)
        {
            sprite.flipX = true;
            saveInputs = SaveInputs.Left;
        }
        if (rb2d.velocity.x <= -0.5f || rb2d.velocity.x >= 0.5f)
        {
            sideMovement = true;
        }
        else { sideMovement = false; }

        if (movement.y > 0)
        {
            upMovement = true;
            downMovement = false;
            saveInputs = SaveInputs.Up;
        }
        else if (movement.y < 0)
        {
            upMovement = false;
            downMovement = true;
            saveInputs = SaveInputs.Down;
        }
        else
        {
            upMovement = false;
            downMovement = false;
        }
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        idleSide = false;
        idleUp = false;
        idleDown = false;
        animLock = true;
        isMelee = false;
        yield return new WaitForSeconds(0.7f);
        isShooting = false;
        animLock = false;
    }

    IEnumerator Melee()
   {
        isMelee = true;
  
        animLock = true;
        isShooting = false;
        yield return new WaitForSeconds(0.5f);
        isMelee = false;
        animLock = false;
    }

    IEnumerator Dash()
    {
        isDash = true;
        animLock = true;
        yield return new WaitForSeconds(0.5f);
        isDash = false;
        animLock = false;
    }

    public bool rangedInput = false;
    public bool meleeInput = false;
    public bool dashInput = false;
    void UpdateAnimation()
    {
        if (rangedInput)
        {
            StartCoroutine(Shoot());
        }

        if (meleeInput)
        {
            if(!playerClass.meleeWeapon.attackOnCooldown)
                StartCoroutine(Melee());
        }

        if (dashInput)
        {
            StartCoroutine(Dash());
        }

        if (!sideMovement && !upMovement && !downMovement && !isShooting && !isMelee && !isDash)
        {
            switch (saveInputs)
            {
                case SaveInputs.Right:
                case SaveInputs.Left:
                    idleSide = true;
                    idleUp = false;
                    idleDown = false;
                    break;
                case SaveInputs.Up:
                    idleSide = false;
                    idleUp = true;
                    idleDown = false;
                    break;
                case SaveInputs.Down:
                    idleSide = false;
                    idleUp = false;
                    idleDown = true;
                    break;
            }
        }
        else
        {
            idleSide = false;
            idleUp = false;
            idleDown = false;
        }
        animator.SetBool("isIdleSide", idleSide);
        animator.SetBool("isIdleUp", idleUp);
        animator.SetBool("isIdleDown", idleDown);
        animator.SetBool("isMovingUp", upMovement);
        animator.SetBool("isMovingDown", downMovement);
        animator.SetBool("isMovingSide", sideMovement);
        animator.SetBool("isShoot", isShooting);
        animator.SetBool("isMelee", isMelee);
        animator.SetBool("isDash", isDash);
    }


    IEnumerator DashTimer()
    {
        yield return new WaitForSeconds(0.1f);
        state = State.Normal;
    }
}
