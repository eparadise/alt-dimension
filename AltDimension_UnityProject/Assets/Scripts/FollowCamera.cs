using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        
        pos.x = player.transform.position.x + offsetX;
        
        
        
        pos.y = player.transform.position.y + offsetY;
        

        transform.position = pos;

    }

    public GameObject player;

    public float offsetX;
    public float offsetY;

}
