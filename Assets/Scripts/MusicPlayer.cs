using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static void PlayClip(int clipIndex)
    {
        AudioSourceController controller = GameObject.FindWithTag("MusicPlayer").GetComponent<AudioSourceController>();
        controller.source.clip = controller.clips[clipIndex];
        controller.source.Stop();
        controller.source.Play();
    }
}
