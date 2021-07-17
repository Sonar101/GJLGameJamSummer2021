using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    private Movement movement;
    private RespawnScreenFader screenFader;
    private bool playerIsRespawning = false;
    public GameObject screenFaderPrefab;
    public Transform respawnLocation;
    
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
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

    public void startPlayerDeath()
    {
        // disable player movement input
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
            Camera.main.transform.position = new Vector3(respawnLocation.position.x, respawnLocation.position.y, Camera.main.transform.position.z);
        }

        playerIsRespawning = false;
        print("Should reset doors");
    }
}
