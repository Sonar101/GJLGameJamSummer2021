using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager current;
    public Vector2 checkPoint;

    public GameObject[] tentacles;

    void Awake()
    {
        if(current == null)
        {
            current = this;
            DontDestroyOnLoad(current);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    public event Action<int> onButtonPress;
    public void ButtonPress(int id)
    {
        if (onButtonPress != null)
            onButtonPress.Invoke(id);
    }

    public event Action onCloseAllDoors;
    public event Action onCameraRumble;
    public void CloseAllDoors()
    {
        if (onCloseAllDoors != null)
            onCloseAllDoors();

        if (onCameraRumble != null)
            onCameraRumble();
    }

    public event Action onDestroyBlackBox;
    public void DestroyBlackBox()
    {
        if (onDestroyBlackBox != null)
            onDestroyBlackBox();

        foreach(GameObject tentacle in tentacles)
        {
            tentacle.SetActive(true);
        }
    }

    public event Action onTryInteract;
    public void TryInteract()
    {
        //Debug.Log("Manager Interact");
        if (onTryInteract != null)
            onTryInteract();
    }

    public event Action<Dialogue> onTriggerDialogue;
    public void TriggerDialogue(Dialogue dialogue)
    {
        if (onTriggerDialogue != null)
            onTriggerDialogue(dialogue);

        Debug.Log(dialogue.sentence);
    }
}
