using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    private AudioSource myAudioSource;
    public AudioClip orbNoise;
    public SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void Collected()
    {
        mySpriteRenderer.enabled = false;
        AudioClip clip = orbNoise;
        myAudioSource.PlayOneShot(clip);
    }
}
