using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -30f);
    }
}
