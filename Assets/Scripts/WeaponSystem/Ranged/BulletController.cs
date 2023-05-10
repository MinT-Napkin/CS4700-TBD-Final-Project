using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float bulletDamage = 10;
    public float bulletSpeed = 20;
    public float bulletRange = 10;
    float distanceTraveled;

    public Animator playerAnimator;
    Vector2 direction;
    SpriteRenderer sprite;

    void Awake()
    {
        playerAnimator = GameObject.FindWithTag("Player").GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        distanceTraveled = 0;
        sprite = GetComponent<SpriteRenderer>();

        if ((playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Side_Shoot")) || (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Side_Shoot")) || (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Side")) || (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk_Side")))
        {
            if (playerAnimator.gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                direction = transform.right;
            }
            else
            {
                direction = -transform.right;
                sprite.flipX = true;
            }
        }
        else if ((playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Up_Shoot")) || (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Up_Shoot")) || (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Idle_Up")) || (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Player_Walk_Up")))
        {    
            direction = transform.up;
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else
        {
            direction = -transform.up;
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }

    void Start()
    {
        rb2d.velocity = direction * bulletSpeed;
    }

    void Update()
    {
        distanceTraveled = distanceTraveled + (bulletSpeed * Time.deltaTime);
        if (distanceTraveled > bulletRange)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {   
            //Damage
            Destroy(gameObject);
        }
    }
}
