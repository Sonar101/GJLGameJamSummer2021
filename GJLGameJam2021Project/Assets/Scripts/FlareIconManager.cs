using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareIconManager : MonoBehaviour
{
    public bool isOn = true;
    public GameObject flare;
    public GameObject flarePlaceHolder;

    public void turnOn()
    {
        flare.SetActive(true);
        flarePlaceHolder.SetActive(false);
        isOn = true;
    }

    public void turnOff()
    {
        flare.SetActive(false);
        flarePlaceHolder.SetActive(true);
        isOn = false;
    }
}
