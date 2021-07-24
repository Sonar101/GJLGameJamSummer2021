using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : Interactable
{
    public int buttonID = -1;
    public AudioSource buttonPressSFX;
    public Animator leverAnim;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        LevelManager.current.onCloseAllSwitches += CloseSwitch;
    }

    protected override void Interact()
    {
        if (LevelManager.current.GetBlackBoxBroken())
        {
            buttonPressSFX?.Play();
            leverAnim.SetBool("LeverOn", true);
            LevelManager.current.ButtonPress(buttonID);
        } else
        {
            leverAnim.SetTrigger("LockingUp");
        }
    }

    protected void CloseSwitch()
    {
        leverAnim.SetBool("LeverOn", false);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
