using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager current;

    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    public event Action<Dialogue> onTriggerDialogue;
    public void TriggerDialogue(Dialogue dialogue)
    {
        if (onTriggerDialogue != null)
            onTriggerDialogue(dialogue);
    }
}
