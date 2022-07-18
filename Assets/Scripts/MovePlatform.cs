using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed;
    public Transform[] points;

    public PressurePlate plate;

    private int i; //index of array
    void Start()
    {
        plate = GetComponent<PressurePlate>();
    }

    private void Update()
    {
        if (plate.pressureOn == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        }
    }
}
