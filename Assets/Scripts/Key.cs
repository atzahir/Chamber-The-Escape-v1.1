using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = FindObjectOfType<PlayerController>();
            if (player)
            {
                player.TakeKey();
                gameObject.SetActive(false);
            }
        }
    }
}
