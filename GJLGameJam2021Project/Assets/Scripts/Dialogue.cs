using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogueType
{
    CEO,
    MONOLOGUE,
    LOG
}

[System.Serializable]
public class Dialogue 
{
    public DialogueType dialogueType;
    public string sentence;
}
