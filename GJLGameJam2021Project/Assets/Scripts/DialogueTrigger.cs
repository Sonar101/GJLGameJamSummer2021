using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : LevelTrigger
{
    public Dialogue dialogue;

    protected override void Trigger()
    {
        LevelManager.current.TriggerDialogue(dialogue);
    }
}
