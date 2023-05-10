using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set;}
    private AudioSource source;

    //Player
    public AudioClip dashSound;
    public AudioClip meleeSound;
    public AudioClip rangeSound;
    public AudioClip flamethrowerSound;
    public AudioClip shieldSound;
    public AudioClip lightningBoltSound;
    public AudioClip doomBladesSound;
    public AudioClip healSound;
    public AudioClip deathSound;

    //items and inventory
    public AudioClip upgradeSound;
    public AudioClip pickUpSound;
    public AudioClip levelUpSound;

    //Enemy
    public AudioClip enemyDeathSound;
    public AudioClip BTRMeleeSound;
    public AudioClip CGRangeSound;
    public AudioClip CSMeleeSound;
    public AudioClip ESMeleeSound;
    public AudioClip ESRangeSound;
    public AudioClip FESMeleeSound;
    public AudioClip FESRangeSound;
    public AudioClip MGMeleeSound;
    public AudioClip PRMeleeSound;
    public AudioClip PRRangeSound;
    public AudioClip SRMeleeSound;
    public AudioClip SEMeleeSound;

    public AudioClip gangBossDeathSound;
    public AudioClip gangBossRangeSound;
    public AudioClip gangBossMeleeSound;
    public AudioClip gangBossFlameSound;

    public AudioClip oldAIBossDeathSound;
    public AudioClip oldAIBossMeleeSound;
    public AudioClip oldAIBossAOESound;
    public AudioClip oldAIBossDashSound;

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