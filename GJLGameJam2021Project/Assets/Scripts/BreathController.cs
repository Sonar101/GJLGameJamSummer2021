using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathController : MonoBehaviour
{
    public RandomAudioClip inhaleSFX;
    public RandomAudioClip exhaleSFX;
    public ParticleSystem  exhaleBubbles;

    public float breatheTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Breathe());
    }

    IEnumerator Breathe()
    {
        while (true)
        {
            yield return new WaitForSeconds(breatheTime);

            inhaleSFX.playRandom();
            exhaleBubbles.Stop();

            yield return new WaitForSeconds(breatheTime);

            exhaleSFX.playRandom();
            exhaleBubbles.Play();
        }
    }
}
