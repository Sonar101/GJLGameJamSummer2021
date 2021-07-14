using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float moveDuration = 1;
    public float rotationOffset = 90f;

    Vector3 closedRotation;
    Vector3 openRotation;

    bool open = false;
    float progress = 0;

    // Start is called before the first frame update
    void Start()
    {
        closedRotation = transform.rotation.eulerAngles;
        openRotation = closedRotation;
        openRotation.z += rotationOffset;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleOpen();
        }

        if ((open && progress <= 1) || (!open && progress >= 0))
        {
            progress += Time.deltaTime / moveDuration * (open ? 1 : -1);
            LerpRotation(progress);
        }
    }

    void ToggleOpen()
    {
        open = !open;
    }

    private void LerpRotation(float progress)
    {
        transform.rotation = Quaternion.Slerp(Quaternion.Euler(closedRotation),
                                              Quaternion.Euler(openRotation),
                                              progress);
    }
}
