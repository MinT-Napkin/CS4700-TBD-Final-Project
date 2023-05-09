using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set;}
    private AudioSource source;

    public AudioClip dashSound;
    public AudioClip meleeSound;
    public AudioClip rangeSound;
    public AudioClip flamethrowerSound;
    public AudioClip shieldSound;
    public AudioClip lightningBoltSound;
    public AudioClip doomBladesSound;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip _sound)
    {
        source.PlayOneShot(_sound);
    }
}