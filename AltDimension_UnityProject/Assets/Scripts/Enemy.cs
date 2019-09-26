using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D myRb2D;
    private SpriteRenderer spriteRenderer;
    //public Sprite spriteWiggle;
    //public Sprite spriteFlat;
    private Vector3 moveDirection = Vector3.forward;

    private float timeLeft = 3.0f;
    public float speed;
    private bool swapSprite = true;
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
        //switchDirections = false;
        /* if (swapSprite)
        {
            spriteRenderer.sprite = spriteWiggle;
            swapSprite = false;
        }
        else
        {
            spriteRenderer.sprite = spriteFlat;
            swapSprite = true;
        } */

        Vector2 velocity = myRb2D.velocity;

        if (timeLeft < 0)
        {
            timeLeft = 3.0f;
            switchDirections = true;
        }
        if (switchDirections)
        {
            if(movingRight)
            {
                velocity.x = -speed;
                
            }
            else
            {
                velocity.x = speed;
                
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
