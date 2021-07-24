using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareSpawner : MonoBehaviour
{
    private bool[] flareTracker;

    public bool showLocationsOnlyWhenSelected = true;
    public GameObject flarePrefab;
    public Transform[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        // force all locations to have 0 for z position
        foreach (Transform loc in spawnLocations)
        {
            loc.position = new Vector3(loc.position.x, loc.position.y, 0f);
        }

        // set up flare tracker
        flareTracker = new bool[spawnLocations.Length];
        for (int i = 0; i < flareTracker.Length; i++)
        {
            flareTracker[i] = true;
        }

        // add respawn method to level manager
        LevelManager.current.onRespawnAllFlares += RespawnFlares;

        SpawnFlares();
    }

    private void SpawnFlares()
    {
        for (int i = 0; i < spawnLocations.Length; i++)
        {
            GameObject currFlare = Instantiate(flarePrefab, spawnLocations[i].position, Quaternion.identity, this.transform);
            currFlare.GetComponent<FlarePickup>().SetupValues(i, this);
        }
    }

    public void RespawnFlares()
    {
        for (int i = 0; i < flareTracker.Length; i++)
        {
            if (!flareTracker[i])
            {
                GameObject currFlare = Instantiate(flarePrefab, spawnLocations[i].position, Quaternion.identity, this.transform);
                currFlare.GetComponent<FlarePickup>().SetupValues(i, this);

                flareTracker[i] = true;
            }
        }
    }

    public void markFlareInTracker(int index)
    {
        flareTracker[index] = false;
    }

    private void OnDrawGizmos()
    {
        if (!showLocationsOnlyWhenSelected)
        {
            foreach (Transform loc in spawnLocations)
            {
                Gizmos.DrawWireCube(loc.position, new Vector3(1f, 1f, 1f));
            }
        }
    }


    private void OnDrawGizmosSelected()
    {
        if (showLocationsOnlyWhenSelected)
        {
            foreach (Transform loc in spawnLocations)
            {
                Gizmos.DrawWireCube(loc.position, new Vector3(1f, 1f, 1f));
            }
        }
    }
}
