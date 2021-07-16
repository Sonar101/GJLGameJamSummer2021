using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected bool inRange = false;

    protected virtual void Start()
    {
        LevelManager.current.onInteract += Interact;
    }

    protected virtual void Interact() { }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = false;
        }
    }

    protected virtual void OnDestroy()
    {
        LevelManager.current.onInteract -= Interact;
    }
}