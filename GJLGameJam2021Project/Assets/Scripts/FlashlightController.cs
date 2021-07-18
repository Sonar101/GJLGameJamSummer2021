using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashlightController : MonoBehaviour
{
    public float maxIntensity = 0.5f;
    public float maxFlickerDuration = 0.2f;

    public RandomAudioClip flickerSFX;

    float progress = 1;
    float flickerAmt = 1;

    bool flickering = false;

    Light2D flashlight;
    const float timestep = 0.1f;

    private void Start()
    {
        flashlight = GetComponent<Light2D>();
        flashlight.enabled = false;

        StartCoroutine(FlickerTimer());
    }

    private void Update()
    {
        if (flickering)
            flickerAmt = Random.value;
        else if (!flickering && flickerAmt != 1)
            flickerAmt = 1;

        flashlight.intensity = progress * flickerAmt * maxIntensity;
    }

    public bool ToggleFlashlight ()
    {
        flashlight.enabled = !flashlight.enabled;
        return flashlight.enabled;
    }

    public void DisableFlashlight()
    {
        flashlight.enabled = false;
    }

    public void SetProgress(float intensity)
    {
        progress = Mathf.Pow(intensity, 0.2f);
    }

    IEnumerator FlickerTimer()
    {
        while (true) {
            yield return new WaitForSeconds(timestep);
            if (flashlight.enabled)
            {
                
                if (Random.value > Mathf.Pow(progress, 0.2f))
                {
                    flickering = true;
                    flickerSFX.playRandom();
                    yield return new WaitForSeconds(Random.value * maxFlickerDuration);
                    flickering = false;
                    flickerSFX.stop();
                }
            }
        }
    }
}
