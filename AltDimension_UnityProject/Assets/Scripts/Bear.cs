using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    private SpriteRenderer mySR;
    private Rigidbody2D myRb2d;
    public Sprite angryBear;

    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        myRb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mySR.sprite = angryBear;
        }
    }
}
