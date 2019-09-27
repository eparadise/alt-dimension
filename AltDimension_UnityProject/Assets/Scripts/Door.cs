using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public Sprite openDoorSprite;

    public bool isOpen = false;
    private SpriteRenderer mySR;
    // Start is called before the first frame update
    void Start()
    {
        mySR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openDoor()
    {
        isOpen = true;
        mySR.sprite = openDoorSprite;
    }
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOpen)
            {
                SceneManager.LoadScene("BeaScene");
            }
        }
    }
    
}
