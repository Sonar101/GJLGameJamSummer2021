using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class UImanager : MonoBehaviour
{
    public int flareNum;
    public GameObject player;
    private PlayerController PlayerController;
    private FlareIconManager flareIconManager;
    private Light2D fs;

    public GameObject flareIcon1;
    public GameObject flareIcon2;
    public GameObject flareIcon3;
    public GameObject flareIcon4;
    public GameObject flareIcon5;

    public GameObject flashLight;
    private FlashLightUIManager flashLightUI;


    // Start is called before the first frame update
    void Start()
    {
        PlayerController = player.GetComponent<PlayerController>();
        flashLightUI = flashLight.GetComponent<FlashLightUIManager>();
        fs = player.GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        flareNum = PlayerController.curFlareNum;
        ManageFlare(flareIcon1, 1);
        ManageFlare(flareIcon2, 2);
        ManageFlare(flareIcon3, 3);
        ManageFlare(flareIcon4, 4);
        ManageFlare(flareIcon5, 5);
        manageFlashlight();
    }

    private void ManageFlare(GameObject flare, int x)
    {
        flareIconManager = flare.GetComponent<FlareIconManager>();
        if (flareNum >= x)
        {
            if (!flareIconManager.isOn)
            {
                flareIconManager.turnOn();
            }
        } else
        {
            if (flareIconManager.isOn)
            {
                flareIconManager.turnOff();
            }
        }
    }

    private void manageFlashlight()
    {
        if (PlayerController.curFlashlightCharge > 0)
        {
            if (fs.enabled)
            {
                flashLightUI.turnOn();
            } else
            {
                flashLightUI.turnOff();
            }        
        }
        else
        {
            flashLightUI.setBroken();
        }
    }
}
