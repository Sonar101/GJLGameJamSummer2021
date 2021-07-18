using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlareBehavior : MonoBehaviour
{
    public float lifetime = 5f;
    public float fadetime = 1f;

    ParticleSystem psFlare;
    ParticleSystem psSmoke;
    Light2D lightFlare;

    float lightIntensity;
    bool fade = false;

    // Start is called before the first frame update
    void Start()
    {
        psFlare = GetComponentInChildren<ParticleSystem>();
        psSmoke = GetComponentInChildren<ParticleSystem>();
        lightFlare = GetComponentInChildren<Light2D>();

        lightIntensity = lightFlare.intensity;

        StartCoroutine(FadeOut(lifetime, fadetime));
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (fade)
        {
            lightFlare.intensity -= Time.deltaTime * lightIntensity / fadetime;
        }
    }

    IEnumerator FadeOut (float lifeT, float fadeT)
    {
        yield return new WaitForSeconds(lifeT - fadeT);
        fade = true;
    }
}
