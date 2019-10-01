using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public GameObject player;
    public GameObject door;

    public float offsetX;
    public float offsetY;
    public float doorOffsetX;
    public float doorOffsetY;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        if (player != null)
        {
            pos.x = player.transform.position.x + offsetX;
            pos.y = player.transform.position.y + offsetY;

        }
        else
        {
            pos.x = door.transform.position.x + doorOffsetX;
            pos.y = door.transform.position.y + doorOffsetY;
        }


        transform.position = pos;

    }


}
