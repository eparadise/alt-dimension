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
    public float shakeTimer = 2;

    private bool isShaking = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;
        if (!isShaking)
        {
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

    public void CameraShake()
    {
        isShaking = true;
        StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine()
    {
        float startTime = Time.time;
        while (startTime + shakeTimer > Time.time)
        {
            if (transform.position.x < 0)
            {
                transform.position = transform.position + 0.5f * Random.onUnitSphere;
            }
            else
            {
                transform.position = transform.position - 0.5f * Random.onUnitSphere;
            }
            yield return new WaitForSeconds(0.05f);
        }
        isShaking = false;

    }


}
