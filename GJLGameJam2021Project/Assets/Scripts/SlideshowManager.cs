using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideshowManager : MonoBehaviour
{
    public float timeBetweenSlides = 4f; // (in seconds)
    public Animator[] animators;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunThroughSlides());
    }

    IEnumerator RunThroughSlides()
    {
        foreach (Animator anim in animators)
        {
            anim.SetBool("FadingUp", true);
            yield return new WaitForSecondsRealtime(timeBetweenSlides);
        }
        SceneManager.LoadScene("LevelDesignTestScene", LoadSceneMode.Single);
    }
}