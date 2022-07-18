using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float speed;
    public Transform points;

    public GameObject platform;

    private int i;
    public bool pressureOn;


    private void Start()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Ground")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if(distance < 1.0f)
            {
                Rigidbody2D box = other.GetComponent<Rigidbody2D>();
                if(box != null)
                {
                    pressureOn = true;
                    if(pressureOn == true)
                    {
                        platform.transform.position = Vector2.MoveTowards(platform.transform.position, points.position, speed * Time.deltaTime);
                    }
                }
            }
        }
    }

/*    private void OnTriggerExit2D(Collider2D other)
    {  
        Rigidbody2D box = other.GetComponent<Rigidbody2D>();
        if (box != null)
        {
            pressureOn = false;
            if (pressureOn == false)
            {
                platform.transform.position = Vector2.MoveTowards(points.position, platform.transform.position, speed * Time.deltaTime);
            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
