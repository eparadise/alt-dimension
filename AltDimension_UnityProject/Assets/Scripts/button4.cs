using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button4 : MonoBehaviour
{
    public button1 button;
    public static void nextIntro()
    {
        SceneManager.LoadScene("IntroScene4");
    }

}
