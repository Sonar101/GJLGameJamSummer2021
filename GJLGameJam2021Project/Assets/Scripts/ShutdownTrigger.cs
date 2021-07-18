using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutdownTrigger : LevelTrigger
{
    //public AudioSource roarSFX;

    protected override void Trigger()
    {
        //roarSFX?.Play();
        LevelManager.current.CloseAllDoors();
        Debug.Log("Shutting down");
    }
}
