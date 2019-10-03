using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level5Button : MonoBehaviour
{
    public GameManager myGameManager;
    public void Menu()
    {
        if (myGameManager.GetLastUnlocked() >= 8)
        {
            SceneManager.LoadScene("ElizaScene2");
        }
    }
}
