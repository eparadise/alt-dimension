using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level5Button : MonoBehaviour
{
    public GameManager myGameManager;

    public void Awake()
    {
        GetComponent<Button>().interactable = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene("ElizaScene2");
    }

    public void Update()
    {
        if (myGameManager.GetLastUnlocked() >= 8)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
