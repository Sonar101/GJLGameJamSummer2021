using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text ceoText;
    public Text selfText;
    public Animator ceoTextAnimator;
    public Animator selfTextAnimator;

    public float typingSpeed = .01f;
    public float timeBeforeClose = 7f; // (in seconds)

    private IEnumerator currCeoCoroutine;
    private IEnumerator currSelfCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            openAndWriteCeoText("Hi text, I'm dad I'm so happy to finally meet you I just wanted to add a lot of text to test the amount of time it takes to put text on the screen");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            openAndWriteSelfText("Oh boy look at me I'm self text thank goodness you created me");
        }
    }

    // --- Ceo Text Functions
    public void openAndWriteCeoText(string sentence)
    {
        ceoTextAnimator.SetBool("IsOpen", true);
        if (currCeoCoroutine != null)
        {
            StopCoroutine(currCeoCoroutine);
        }
        currCeoCoroutine = TypeCeoSentence(sentence);
        StartCoroutine(currCeoCoroutine);
    }

    IEnumerator TypeCeoSentence(string sentence)
    {
        ceoText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            ceoText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
        yield return new WaitForSecondsRealtime(timeBeforeClose);
        closeCeoText();
    }

    private void closeCeoText()
    {
        ceoTextAnimator.SetBool("IsOpen", false);
    }

    // --- Self Text Functions
    public void openAndWriteSelfText(string sentence)
    {
        selfTextAnimator.SetBool("IsOpen", true);
        if (currSelfCoroutine != null)
        {
            StopCoroutine(currSelfCoroutine);
        }
        currSelfCoroutine = TypeSelfSentence(sentence);
        StartCoroutine(currSelfCoroutine);
    }

    IEnumerator TypeSelfSentence(string sentence)
    {
        selfText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            selfText.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
        yield return new WaitForSecondsRealtime(timeBeforeClose);
        closeSelfText();
    }

    private void closeSelfText()
    {
        selfTextAnimator.SetBool("IsOpen", false);
    }
}
