using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip orbNoise;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }


    public void Collected()
    {
        AudioClip clip = orbNoise;
        myAudioSource.PlayOneShot(clip);
    }
}
