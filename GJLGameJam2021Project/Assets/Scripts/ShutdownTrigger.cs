using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownTrigger : LevelTrigger
{
    protected override void Trigger()
    {
        LevelManager.current.CloseAllDoors();
        Debug.Log("Shutting down");
    }
}
