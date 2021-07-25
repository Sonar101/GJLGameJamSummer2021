using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlideshowManager : MonoBehaviour
{
    public float timeBetweenSlides = 4f; // (in seconds)
    public Animator[] animators;

    public AudioSource[] SFX;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunThroughSlides());
    }

    IEnumerator RunThroughSlides()
    {
        int i = 0;
        foreach (Animator anim in animators)
        {
            anim.SetBool("FadingUp", true);
            yield return new WaitForSecondsRealtime(timeBetweenSlides);

            if (i < SFX.Length && SFX[i] != null)
                SFX[i]?.Play();
            i++;
        }
        SceneManager.LoadScene("LevelDesignTestScene", LoadSceneMode.Single);
    }

    public void skip()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Unload/Reset the next scenes if they've already been loaded
        if (SceneManager.GetSceneByBuildIndex(nextSceneIndex).isLoaded)
        {
            SceneManager.UnloadSceneAsync(nextSceneIndex);
        }
        if (SceneManager.GetSceneByBuildIndex(nextSceneIndex + 1).isLoaded)
        {
            SceneManager.UnloadSceneAsync(nextSceneIndex + 1);
        }

        // Load and play the next scene
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    }
}
