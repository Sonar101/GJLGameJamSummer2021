using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public bool triggerOnce = true;
    protected bool hasTriggered = false;

    protected virtual void Trigger()
    {
        Debug.Log("No assigned trigger");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!triggerOnce || (triggerOnce && !hasTriggered))
            {
                Trigger();
                hasTriggered = true;
            }
        }
    }
}
