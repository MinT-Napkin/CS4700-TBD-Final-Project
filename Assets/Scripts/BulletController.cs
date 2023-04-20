using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public BulletData bulletData;
    Rigidbody2D rb2d;
    public float bulletStrength;
    public float bulletSpeed;
    public float bulletRange;
    float distanceTraveled;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distanceTraveled = 0;
        bulletStrength = bulletData.bulletStrength;
        bulletRange = bulletData.bulletRange;
        bulletSpeed = bulletData.bulletSpeed;
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
