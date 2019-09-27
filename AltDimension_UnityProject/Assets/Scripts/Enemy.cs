﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myRb2D;
    private SpriteRenderer spriteRenderer;
    public Sprite spriteWiggle;
    public Sprite spriteFlat;
    private Vector3 moveDirection = Vector3.forward;

    private float timeLeft = 1.5f;
    public float speed;
    private bool wiggle = true;
    private float spriteTimer = 0.25f;
    private bool switchDirections;
    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        spriteTimer -= Time.deltaTime;
        
        if (spriteTimer < 0)
        {
            spriteTimer = 0.25f;
            if(wiggle)
            {
                spriteRenderer.sprite = spriteWiggle;
                wiggle = false;
            }
            else
            {
                spriteRenderer.sprite = spriteFlat;
                wiggle = true;
            }
        }

        Vector2 velocity = myRb2D.velocity;

        if (timeLeft < 0)
        {
            timeLeft = 1.5f;
            switchDirections = true;
        }

        if (switchDirections)
        {
            if(movingRight)
            {
                velocity.x = -speed;
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                velocity.x = speed;
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (movingRight)
            {
                velocity.x = speed;
            }
            else
            {
                velocity.x = -speed;
            }
        }

        myRb2D.velocity = velocity;
    }


}
