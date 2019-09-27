using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //public int numOrbs;

    private static int lives = 3;
    //private int orbCount = 0;
    private UIHealthPanel hpanel;

    // Start is called before the first frame update
    void Start()
    {
        hpanel = GameObject.FindObjectOfType<UIHealthPanel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            OrbManager.instance.OrbCollected();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy")) {
            lives--;
            hpanel.UpdateHearts(lives);
            if (lives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
