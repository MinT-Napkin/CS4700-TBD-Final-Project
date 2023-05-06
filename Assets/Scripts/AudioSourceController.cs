using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();
    }
}
