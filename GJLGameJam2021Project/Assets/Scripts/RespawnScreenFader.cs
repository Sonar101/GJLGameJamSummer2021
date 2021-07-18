using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScreenFader : MonoBehaviour
{
    private RespawnManager respawner;
    public Animator animator;

    public void FadeOutForRespawn()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        respawner.resetPlayerAndLevel();
        animator.SetTrigger("FadeBackIn");
    }

    public void setRespawnManager(RespawnManager rm)
    {
        respawner = rm;
    }
}
