using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6Button : MonoBehaviour
{
    public GameManager myGameManager;
    public void Menu()
    {
        if (myGameManager.GetLastUnlocked() >= 9)
        {
            SceneManager.LoadScene("DelaneyScene2");
        }
    }
}
