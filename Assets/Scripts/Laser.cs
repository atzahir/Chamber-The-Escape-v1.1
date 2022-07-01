using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private GameObject Lasers;
    private bool trapEnabled = true;
    public float laserDuration;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ToggleLaserTrap", 0, (laserDuration));
    }

    private void ToggleLaserTrap()
    {
        trapEnabled = !trapEnabled;
        Lasers.SetActive(trapEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
