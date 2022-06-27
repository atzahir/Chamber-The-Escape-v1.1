using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float timeTilSpawn;
    public float startTimeTilSpawn;

    public GameObject laser;
    public Transform whereToSpawn;
    // Update is called once per frame
    void Update()
    {
        if(timeTilSpawn <= 0)
        {
            Instantiate(laser, whereToSpawn.position, whereToSpawn.rotation);

            timeTilSpawn = startTimeTilSpawn;
        }
        else
        {
            timeTilSpawn -= Time.deltaTime;
        }
    }
}
