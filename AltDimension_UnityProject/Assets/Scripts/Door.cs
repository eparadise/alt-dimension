using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    public Sprite openDoorSprite;
    public Sprite[] doorSprites;
    public int framesPerSecond = 1;
    public Camera mainCamera;

    public bool isOpen = false;
    private SpriteRenderer mySR;
    private SpriteRenderer playerSR;
    // Start is called before the first frame update
    void Start()
    {
        mySR = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenDoor()
    {
        isOpen = true;
        mySR.sprite = openDoorSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isOpen)
            {
                Destroy(collision.gameObject);
                mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 1, mainCamera.transform.position.z);
                StartCoroutine(DoorAnimation());
            }
        }
    }

    IEnumerator DoorAnimation()
    {
        GameObject playerAnimation = new GameObject();
        playerSR = playerAnimation.AddComponent<SpriteRenderer>();
        playerAnimation.transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z) ;
        int currentFrameIndex = 0;
        while (currentFrameIndex < doorSprites.Length)
        {
            playerSR.sprite = doorSprites[currentFrameIndex];
            yield return new WaitForSeconds(1f / framesPerSecond);
            currentFrameIndex++;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
