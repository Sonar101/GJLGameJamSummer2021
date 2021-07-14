using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashlightController : MonoBehaviour
{
    Light2D flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light2D>();
        flashlight.enabled = false;
    }

    public bool ToggleFlashlight ()
    {
        flashlight.enabled =  !flashlight.enabled;
        return flashlight.enabled;
    }

    public void DisableFlashlight()
    {
        flashlight.enabled = false;
    }

    public void SetIntensity(float intensity)
    {
        flashlight.intensity = intensity;
    }
}
