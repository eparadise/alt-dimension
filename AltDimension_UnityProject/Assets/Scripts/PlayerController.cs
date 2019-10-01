using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public int numOrbs;
    public float framesPerSecond;
    public Sprite[] doorSprites;

    private static int lives = 3;
    private SpriteRenderer mySpriteRenderer;
    //private int orbCount = 0;
    private UIHealthPanel hpanel;
    public LayerMask playerLayerMask;
    public bool killEnemy;

    // Start is called before the first frame update
    void Start()
    {
        hpanel = GameObject.FindObjectOfType<UIHealthPanel>();
        mySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D jumpingOn = Physics2D.Raycast(transform.position, Vector2.down, 2, playerLayerMask, -Mathf.Infinity, Mathf.Infinity);
        if(jumpingOn.collider != null)
        { 
            GameObject myObj = jumpingOn.collider.gameObject;
            if(myObj.CompareTag("Enemy"))
            {
                killEnemy = true;
            }
        }
        else
        {
            killEnemy = false;
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
                Destroy(collision.gameObject);
            }
            else
            {
                lives--;
                hpanel.UpdateHearts(lives);
                if (lives == 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            if (collision.gameObject.GetComponent<Door>().isOpen)
            {
                StartCoroutine(DoorAnimation());
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    IEnumerator DoorAnimation()
    {
        int currentFrameIndex = 0;
        while (currentFrameIndex < doorSprites.Length)
        {
            mySpriteRenderer.sprite = doorSprites[currentFrameIndex];
            yield return new WaitForSeconds(1f / framesPerSecond);
            currentFrameIndex++;
        }
        Destroy(gameObject);
    }
}
