using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UImanager : MonoBehaviour
{
    public int flareNum;
    public GameObject player;
    private PlayerController PlayerController;
    private FlareIconManager flareIconManager;

    public GameObject flareIcon1;
    public GameObject flareIcon2;
    public GameObject flareIcon3;
    public GameObject flareIcon4;
    public GameObject flareIcon5;


    // Start is called before the first frame update
    void Start()
    {
        PlayerController = player.GetComponent<PlayerController>();
        
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
}
