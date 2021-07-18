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

    private void Start()
    {
        LevelManager.current.onTriggerDialogue += parseDialog;
    }

    void parseDialog (Dialogue dialogue)
    {
        if (dialogue.dialogueType == DialogueType.CEO)
        {
            openAndWriteCeoText(dialogue.sentence);
        } else if (dialogue.dialogueType == DialogueType.MONOLOGUE)
        {
            openAndWriteSelfText(dialogue.sentence);
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

    private void onDestroy()
    {
        LevelManager.current.onTriggerDialogue -= parseDialog;
    }
}
