using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ProximityGlow : MonoBehaviour
{
    private Transform playerTransform;
    private Light2D light;
    public float maxDistance = 3f;
    public float maxIntensity = .83f;
    public float lerpRate = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponentInParent<EnemyAI>().Player;
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) < maxDistance)
        {
            light.intensity = Mathf.Lerp(light.intensity, maxIntensity, lerpRate);
        }
        else
        {
            light.intensity = Mathf.Lerp(light.intensity, 0f, lerpRate);
        }
    }
}
