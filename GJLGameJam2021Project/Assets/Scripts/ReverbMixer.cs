using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ReverbMixer : MonoBehaviour
{
    public float transitionTime = 0.5f;

    public AudioMixerSnapshot Hallway;
    public AudioMixerSnapshot Room;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            Room.TransitionTo(transitionTime);
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            Hallway.TransitionTo(transitionTime);
    }
}
