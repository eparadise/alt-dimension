using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Delaney Sears
public class Orb : MonoBehaviour
{

    float orbCount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gainOrb()
    {
        orbCount++;
        Destroy(gameObject);
    }
}
