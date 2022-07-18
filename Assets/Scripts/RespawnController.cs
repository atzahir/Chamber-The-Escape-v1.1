using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{   
    public PlayerController gamePlayer;
    public float respawnDelay;

    private void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
    }

    public void Respawn()
    {
        StartCoroutine (RespawnCoroutine());
    } 

    IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        PlayerPrefs.SetInt("falling_spiked_platform_spawn", 1);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
}