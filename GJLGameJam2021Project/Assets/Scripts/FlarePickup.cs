using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlarePickup : MonoBehaviour
{
    private int index;
    private FlareSpawner flareSpawner;

    public void SetupValues(int indexVal, FlareSpawner flareSpawnerRef)
    {
        index = indexVal;
        flareSpawner = flareSpawnerRef;
    }

    public int GetIndex()
    {
        return index;
    }

    private void OnDestroy()
    {
        if (flareSpawner != null)
            flareSpawner.markFlareInTracker(index);
    }
}
