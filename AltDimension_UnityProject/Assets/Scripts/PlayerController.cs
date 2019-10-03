using System.Collections;
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
    private bool isHurt;
    private Rigidbody2D myRb2D;
    private AudioSource myAudioSource;
    public AudioClip hurtNoise;

    // Start is called before the first frame update
    void Start()
    {
        hpanel = GameObject.FindObjectOfType<UIHealthPanel>();
        mainCamera = GameObject.FindObjectOfType<Camera>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        myRb2D = gameObject.GetComponent<Rigidbody2D>();
        isHurt = false;
        myAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        hpanel.UpdateHearts(lives);
        killEnemy = false;
        RaycastHit2D jumpingOn = Physics2D.CircleCast(transform.position, 0.7f / 2.0f, Vector2.down, 1, snakeLayerMask);
        if (jumpingOn.collider != null)
        {
            GameObject myObj = jumpingOn.collider.gameObject;
            if (myObj.CompareTag("Enemy") && myRb2D.velocity.y < 0)
            {
                killEnemy = true;
            }
        }
        if(transform.position.y < -25)
        {
            lives--;
            hpanel.UpdateHearts(lives);
            if (lives == 0)
            {

                Die();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (killEnemy)
            {
                collision.gameObject.GetComponent<Enemy>().Hurt();
            }
            else
            {
                if (!collision.gameObject.GetComponent<Enemy>().isHurt && !isHurt)
                {

                    lives--;
                    AudioClip clip = hurtNoise;
                    myAudioSource.PlayOneShot(clip);
                    //hpanel.UpdateHearts(lives);
                    if (lives == 0)
                    {
                        hpanel.UpdateHearts(lives);
                        Die();
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
        isHurt = false;
        hpanel.UpdateHearts(lives);
    }

    private void Die()
    {
        lives = 3;
        GameManager myGameManager = FindObjectOfType<GameManager>();
        myGameManager.SetPrevScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("ElizaDeathScene");
    }
}
