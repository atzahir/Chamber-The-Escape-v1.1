using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public int respawnTime = 2;
    public void Respawning()
    {
        StartCoroutine(DelayedRespawn());
    }

    IEnumerator DelayedRespawn()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
