using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundClip;

    private bool hasPlayed = false;

    public void PlaySoundOnce()
    {
        if (!hasPlayed)
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }

    public void StopSound()
    {
        if(!hasPlayed){
            audioSource.Stop();
            hasPlayed = true;
        }
    }
}
