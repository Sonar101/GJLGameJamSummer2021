using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ProximityGlow : MonoBehaviour
{
    private Transform playerTransform;
    private Light2D greenLight;
    public float maxDistance = 3f;
    public float maxIntensity = .83f;
    public float lerpRate = .5f;
    
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponentInParent<EnemyAI>().Player;
        greenLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(playerTransform.position, transform.position) < maxDistance)
        {
            greenLight.intensity = Mathf.Lerp(greenLight.intensity, maxIntensity, lerpRate);
        }
        else
        {
            greenLight.intensity = Mathf.Lerp(greenLight.intensity, 0f, lerpRate);
        }
    }
}
