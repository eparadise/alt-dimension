using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level4Button : MonoBehaviour
{
    public GameManager myGameManager;

    public void Awake()
    {
        GetComponent<Button>().interactable = false;
    }
    public void Menu()
    {
        SceneManager.LoadScene("BeaScene2");
    }

    public void Update()
    {
        if (myGameManager.GetLastUnlocked() >= 7)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
