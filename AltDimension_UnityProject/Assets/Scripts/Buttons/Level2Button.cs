using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level2Button : MonoBehaviour
{
    public GameManager myGameManager;

    public void Awake()
    {
        GetComponent<Button>().interactable = false;
    }
    public void Menu()
    {
       SceneManager.LoadScene("ElizaScene");
    }

    public void Update()
    {
        if (myGameManager.GetLastUnlocked() >= 5)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
