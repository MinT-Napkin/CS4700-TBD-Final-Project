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

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distanceTraveled = 0;
    }

    void Start()
    {
        rb2d.velocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        distanceTraveled = distanceTraveled + (bulletSpeed * Time.deltaTime);
        if (distanceTraveled > bulletRange)
        {
            Destroy(gameObject);
        }
    }
}
