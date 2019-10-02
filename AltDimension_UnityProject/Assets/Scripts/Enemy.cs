using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite spriteWiggle;
    public Sprite spriteFlat;
    public float hurtTimer = 1;
    public bool isHurt;

    private Rigidbody2D myRb2D;
    private float timeLeft = 1.5f;
    public float speed;
    private bool wiggle = true;
    private float spriteTimer = 0.25f;
    private bool switchDirections;

    // Start is called before the first frame update
    void Start()
    {
        isHurt = false;
        myRb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Vector2 velocity = myRb2D.velocity;
        velocity.x = speed;
        myRb2D.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        spriteTimer -= Time.deltaTime;
        
        
        if (spriteTimer <= 0)
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

        if (timeLeft < 0)
        {
            timeLeft = 1.5f;
            switchDirections = true;
        }

        if (switchDirections)
        {
            swapDirections();
            switchDirections = false;
        }
        
    }

    void swapDirections()
    {
        Vector2 velocity = myRb2D.velocity;
        velocity.x = -velocity.x;
        myRb2D.velocity = velocity;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void Hurt()
    {
        if (!isHurt)
        {
            isHurt = true;
            myRb2D.velocity = new Vector3(0, 0, 0);
            StartCoroutine(HurtRoutine());
        }   
    }

    IEnumerator HurtRoutine()
    {
        float startTime = Time.time;
        while (startTime + hurtTimer > Time.time)
        {
            if (spriteRenderer.color != Color.red)
            {
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }

            yield return new WaitForSeconds(0.1f);
        }
        spriteRenderer.color = Color.white;
        isHurt = false;
        Destroy(gameObject);
    }


}
