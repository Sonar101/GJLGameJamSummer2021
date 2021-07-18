using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathplaneTrigger : LevelTrigger
{
    protected override void Trigger()
    {
        LevelManager.current.DeathplaneTrigger();
    }
}
