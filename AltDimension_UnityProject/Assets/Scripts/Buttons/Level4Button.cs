using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4Button : MonoBehaviour
{
    public GameManager myGameManager;
    public void Menu()
    {
        if (myGameManager.GetLastUnlocked() >= 7)
        {
            SceneManager.LoadScene("BeaScene2");
        }
    }
}
