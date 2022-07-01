﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{   
    public PlayerMovement gamePlayer;
    public float respawnDelay;


    private void Start()
    {
        gamePlayer = FindObjectOfType<PlayerMovement>();
    }

    

    public void Respawn()
    {
        StartCoroutine (RespawnCoroutine());
    } 

    IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
}