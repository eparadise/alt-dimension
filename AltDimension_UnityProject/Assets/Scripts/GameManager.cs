using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string prevScene;
    public static int lastUnlockedIndex = 4;

    public void SetPrevScene(string name)
    {
        prevScene = name;
    }

    public string GetPrevScene()
    {
        return prevScene;
    }

    public void SetLastUnlocked(int index)
    {
        lastUnlockedIndex = index;
    }

    public int GetLastUnlocked()
    {
        return lastUnlockedIndex;
    }
}
