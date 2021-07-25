using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimedTextReveal : MonoBehaviour
{
    private Text textObj;

    public float startDelayTime = 2f;
    public float typingSpeed = 4f; // (in seconds)

    
    // Start is called before the first frame update
    void Start()
    {
        textObj = GetComponent<Text>();
        StartCoroutine(TypeSentence(textObj.text));
    }

    IEnumerator TypeSentence(string sentence)
    {
        textObj.text = "";
        yield return new WaitForSecondsRealtime(startDelayTime);
        foreach (char letter in sentence.ToCharArray())
        {
            textObj.text += letter;
            yield return new WaitForSecondsRealtime(typingSpeed);
        }
    }
}
