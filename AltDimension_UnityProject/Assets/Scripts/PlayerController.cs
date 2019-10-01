﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private static int lives = 3;
    private SpriteRenderer mySpriteRenderer;
    private UIHealthPanel hpanel;
    public LayerMask snakeLayerMask;
    public Camera mainCamera;
    public float hurtTimer = 1;
    private bool killEnemy;
    private bool isHurt = false;

    // Start is called before the first frame update
    void Start()
    {
        hpanel = GameObject.FindObjectOfType<UIHealthPanel>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D jumpingOn = Physics2D.CircleCast(transform.position, 0.7f / 2.0f, Vector2.down, 1, snakeLayerMask);
        killEnemy = false;
        if (jumpingOn.collider != null)
        {
            GameObject myObj = jumpingOn.collider.gameObject;
            if (myObj.CompareTag("Enemy"))
            {
                killEnemy = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            OrbManager.instance.OrbCollected();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy")) {
            if (killEnemy)
            {
                //Destroy(collision.gameObject);
                //mainCamera.GetComponent<FollowCamera>().CameraShake();
                collision.gameObject.GetComponent<Enemy>().Hurt();
                //StartCoroutine(HurtRoutine());
            }
            else
            {
                if (!gameObject.GetComponent<Enemy>().isHurt && !isHurt)
                {
                    
                    lives--;
                    if (lives == 0)
                    {
                        hpanel.UpdateHearts(lives);
                        //die coroutine here
                        lives = 3;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    }
                    else
                    {
                        mainCamera.GetComponent<FollowCamera>().CameraShake();
                        StartCoroutine(HurtRoutine());
                    }
                }
             
            }
        }
    }

    IEnumerator HurtRoutine()
    {
        float startTime = Time.time;
        while (startTime + hurtTimer > Time.time)
        {
            if (mySpriteRenderer.color != Color.black)
            {
                mySpriteRenderer.color = Color.black;
            }
            else
            {
                mySpriteRenderer.color = Color.white;
            }

            yield return new WaitForSeconds(0.1f);
        }
        mySpriteRenderer.color = Color.white;
        hpanel.UpdateHearts(lives);
    }
}
