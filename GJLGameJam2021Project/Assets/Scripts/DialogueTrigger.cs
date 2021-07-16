using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool triggerOnce = true;

    private bool hasTriggered = false;

    private void TriggerDialogue() {
        if (!triggerOnce || (triggerOnce && !hasTriggered))
        {
            DialogueManager.current.TriggerDialogue(dialogue);
            hasTriggered = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TriggerDialogue();
        }
    }
}
