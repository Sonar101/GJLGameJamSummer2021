using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private PlayerController pc;
    private RespawnScreenFader screenFader;
    private bool playerIsRespawning = false;
    public GameObject screenFaderPrefab;
    public Transform respawnLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        screenFader = Instantiate(screenFaderPrefab).GetComponent<RespawnScreenFader>();
        screenFader.setRespawnManager(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy") && !playerIsRespawning)
        {
            startPlayerDeath();
            playerIsRespawning = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !playerIsRespawning)
        {
            startPlayerDeath();
            playerIsRespawning = true;
        }
    }

    public void startPlayerDeath()
    {
        pc.setDeath(true);
        // initiate bubble particle effect
        print("Should stop player movement and trigger bubble particle effect");
        screenFader.FadeOutForRespawn();
    }

    public void resetPlayerAndLevel()
    {
        if (respawnLocation == null) {
            print("Need to set respawn location; not repositioning player");
        } else {
            transform.position = respawnLocation.position;
            pc.setDeath(false);
            Camera.main.transform.position = new Vector3(respawnLocation.position.x, respawnLocation.position.y, Camera.main.transform.position.z);
        }

        playerIsRespawning = false;
        print("Should reset doors");
    }
}
