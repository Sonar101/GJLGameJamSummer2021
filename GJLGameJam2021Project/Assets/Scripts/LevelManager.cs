using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager current;

    void Awake()
    {
        current = this;
    }

    public event Action<int> onButtonPress;
    public void ButtonPress(int id)
    {
        if (onButtonPress != null)
            onButtonPress(id);
    }

    public event Action onCloseAllDoors;
    public void CloseAllDoors()
    {
        if (onCloseAllDoors != null)
            onCloseAllDoors();
    }

    public event Action onInteract;
    public void Interact()
    {
        if (onInteract != null)
            onInteract();
    }
}
