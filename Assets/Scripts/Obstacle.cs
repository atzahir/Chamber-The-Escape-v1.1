using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Deadly" || target.gameObject.tag == "Enemy")
        {
            Die();
        }

        void Die()
        {
            GameObject go = GameObject.Find("RespawnPlayer");
            PlayerRespawn pr = (PlayerRespawn)go.GetComponent(typeof(PlayerRespawn));
            pr.Respawning();
            Destroy(gameObject);
        }
    }
}
