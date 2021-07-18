using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightUIManager : MonoBehaviour
{
    public GameObject flashOn;
    public GameObject flashOff;
    public GameObject flashRip;

    public bool isOn;
    public bool isBroken;
    // Start is called before the first frame update
   void Start()
    {
        isOn = false;
        isBroken = false;

    }

    public void turnOn()
    {
        if (!isOn)
        {
            flashOn.SetActive(true);
            flashOff.SetActive(false);
            isOn = true;
        }
    }

    public void turnOff()
    {
        if (isOn)
        {
            flashOn.SetActive(false);
            flashOff.SetActive(true);
            isOn = false;
        }
    }

    public void setBroken()
    {
        if (!isBroken)
        {
            flashOn.SetActive(false);
            flashOff.SetActive(false);
            flashRip.SetActive(true);
            isBroken = true;
        }
    }
}
