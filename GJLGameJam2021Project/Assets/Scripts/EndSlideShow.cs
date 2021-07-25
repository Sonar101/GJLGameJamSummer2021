using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSlideShow : MonoBehaviour
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
    }

    public void skip()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
