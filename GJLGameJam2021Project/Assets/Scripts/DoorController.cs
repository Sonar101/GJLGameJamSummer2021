using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable
{
    public float moveDuration = 1;
    public float rotationOffset = 90f;

    public int doorID = -1;

    Vector3 closedRotation;
    Vector3 openRotation;

    bool open = false;
    float progress = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        closedRotation = transform.rotation.eulerAngles;
        openRotation = closedRotation;
        openRotation.z += rotationOffset;

        base.Start();
        LevelManager.current.onButtonPress += ButtonOpen;
        LevelManager.current.onCloseAllDoors += Close;
    }

    // Update is called once per frame
    void Update()
    {
        if ((open && progress <= 1) || (!open && progress >= 0))
        {
            progress += Time.deltaTime / moveDuration * (open ? 1 : -1);
            LerpRotation(progress);
        }
    }

    void ToggleState()
    {
        open = !open;
    }

    protected override void Interact()
    {
        ToggleState();
    }

    void ButtonOpen(int id)
    {
        if (doorID == id)
            open = true;
    }

    void Close() { open = false; }

    private void LerpRotation(float progress)
    {
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(closedRotation),
                                              Quaternion.Euler(openRotation),
                                              progress);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        LevelManager.current.onButtonPress -= ButtonOpen;
        LevelManager.current.onCloseAllDoors -= Close;
    }
}
