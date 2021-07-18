using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : Interactable
{
    public int buttonID = -1;
    public AudioSource buttonPressSFX;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    protected override void Interact()
    {
        buttonPressSFX?.Play();
        LevelManager.current.ButtonPress(buttonID);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
