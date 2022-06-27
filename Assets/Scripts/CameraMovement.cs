using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    Vector3 velocity = Vector3.zero;

    //time to follow target
    public float smoothTime = .15f;

    //enable and set the maximum Y value
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //enable and set tha minimium Y value
    public bool YMinEnabled = false;
    public float YMinValue = 0;

    //enable and set the maximum X value
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //enable and set tha minimium X value
    public bool XMinEnabled = false;
    public float XMinValue = 0;


    // Update is called once per frame
    void Update()
    {
        //plyaer position
        Vector3 playerPos = player.position;
        //transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

        //vertical
        if (YMinEnabled && YMaxEnabled)
        {
            playerPos.y = Mathf.Clamp(player.position.y, YMinValue, YMaxValue);
        }
        else if (YMinEnabled)
        {
            playerPos.y = Mathf.Clamp(player.position.y, YMinValue, player.position.y);
        }
        else if (YMinEnabled)
        {
            playerPos.y = Mathf.Clamp(player.position.y, player.position.y, YMaxValue);
        }
        //horizontal
        if (XMinEnabled && XMaxEnabled)
        {
            playerPos.x = Mathf.Clamp(player.position.x, XMinValue, XMaxValue);
        }
        else if (XMinEnabled)
        {
            playerPos.x = Mathf.Clamp(player.position.x, XMinValue, player.position.x);
        }
        else if (XMinEnabled)
        {
            playerPos.x = Mathf.Clamp(player.position.x, player.position.x, XMaxValue);
        }

        playerPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothTime);
    }
}
