using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public static OrbManager instance;

    private int totalOrbs;
    private int orbCount = 0;
    private Door myDoor;            // could be public- only can't access object in scene in prefab


    private void Awake()
    {
        instance = this;   
    }

    // Start is called before the first frame update --> can't call if not Singleton (all static)
    void Start()
    {
        totalOrbs = GameObject.FindObjectsOfType<Orb>().Length;
        myDoor = GameObject.FindObjectOfType<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OrbCollected()
    {
        orbCount++;
        if (orbCount == totalOrbs) {
            myDoor.OpenDoor();
        }
    }
}
