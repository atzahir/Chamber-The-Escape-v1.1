using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private Vector3 respawnPoint;
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy")
        {
            transform.position = respawnPoint;
        }
        else if(target.gameObject.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
        }
    }
}
