using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Button : MonoBehaviour
{
    public GameManager myGameManager;
    public void Menu()
    {
        if (myGameManager.GetLastUnlocked() >= 6)
        {
            SceneManager.LoadScene("BeaScene1");
        }
    }
}
