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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioClip clip = orbNoise;
            myAudioSource.PlayOneShot(clip);
        }
    }
   
}
