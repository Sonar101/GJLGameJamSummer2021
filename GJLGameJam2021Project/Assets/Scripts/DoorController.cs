using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : Interactable
{
    public float moveDuration = 1;
    public float rotationOffset = 90f;
    public float buttonDelayTime = 0.5f;

    public int doorID = -1;

    public AudioSource openSFX;
    public RandomAudioClip closeSFX;

    public bool openAtStart = true;

    Vector3 closedRotation;
    Vector3 openRotation;

    bool open = false;
    float progress = 0;

    bool hasPlayedCloseSound = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        closedRotation = transform.rotation.eulerAngles;
        openRotation = closedRotation;
        openRotation.z += rotationOffset;

        base.Start();
        LevelManager.current.onButtonPress += ButtonOpen;
        LevelManager.current.onCloseAllDoors += CloseAll;

        if (openAtStart)
        {
            progress = 1;
            open = true;
            hasPlayedCloseSound = false;
            LerpRotation(progress);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((open && progress <= 1) || (!open && progress >= 0))
        {
            progress += Time.deltaTime / moveDuration * (open ? 1 : -1);
            LerpRotation(progress);
        }
        if (!open && progress <= 0 && !hasPlayedCloseSound)
        {
            Debug.Log("closing door");
            closeSFX.playRandom();
            hasPlayedCloseSound = true;
        }
    }

    void ToggleState()
    {
        //openSFX.Play();
        open = !open;
    }

    protected override void Interact()
    {
        //ToggleState();
    }

    void ButtonOpen(int id)
    {
        if (doorID == id)
            StartCoroutine(buttonDelay());
    }

    void Close() {
        open = false;
    }

    void CloseAll()
    {
        StartCoroutine(CloseDelay());
    }

    void Open() {
        openSFX.Play();
        open = true;
        hasPlayedCloseSound = false;
    }

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
        LevelManager.current.onCloseAllDoors -= CloseAll;
    }

    IEnumerator buttonDelay()
    {
        yield return new WaitForSeconds(buttonDelayTime);
        Open();
    }

    IEnumerator CloseDelay()
    {
        float timeoffset = buttonDelayTime + (0.1f * doorID);
        Debug.Log(timeoffset);
        yield return new WaitForSeconds(timeoffset);
        Close();
    }
}
