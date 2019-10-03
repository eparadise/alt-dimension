using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{
    public GameManager myGameManager;
    public void Menu()
    {
        if (myGameManager.GetLastUnlocked() >= 5)
        {
            SceneManager.LoadScene("ElizaScene");
        }
       
    }
}
