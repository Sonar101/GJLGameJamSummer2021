using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAudioClip : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] audioClips;

    [Header("Randomness Settings")]
    [Range(0, 1)]
    public float probablity = 1;
    public float pitchVariation;

    [Header("Loop Settings")]
    public bool loopOnStart;
    public float loopTimeMin;
    public float loopTimeMax;

    [Header("Location Settings")]
    public bool randomizeLocation;
    public Vector2 locationBounds = new Vector2(60, 40);

    [HideInInspector]
    public bool isPlaying = false;

    private AudioSource _as;
    private float startPitch;
    
    void Awake()
    {
        // populates the audio source's clip with first in array
        _as = GetComponent<AudioSource>();
        startPitch = _as.pitch;

        if (audioClips.Length != 0 && _as != null)
        {
            _as.clip = audioClips[0];
        }
    }

    private void Start()
    {
        if (loopOnStart)
        {
            StartCoroutine("startRandomLoop");
        }
    }

    void Update()
    {
        if(!isPlaying && _as.isPlaying)
        {
            isPlaying = true;
        }
        else if (isPlaying && !_as.isPlaying)
        {
            isPlaying = false;
        }
    }

    public void playRandom()
    {
        if (Random.Range(0f, 1f) <= probablity)
        {
            if (_as != null)
            {
                if (audioClips.Length > 1)
                {
                    AudioClip newClip;
                    // pick a random clip until it does not equal the current clip
                    do
                    {
                        newClip = audioClips[Random.Range(0, audioClips.Length)];
                    } while (newClip == _as.clip);
                    _as.clip = newClip;
                }
                // add pitch variation based on the original pitch value of the audio source
                if (pitchVariation != 0)
                {
                    _as.pitch = Random.Range(startPitch - pitchVariation, startPitch + pitchVariation);
                }
                if (randomizeLocation)
                {
                    Vector3 randomVec = new Vector3(Random.Range(0f, locationBounds.x), Random.Range(0f, locationBounds.y), 0);
                    AudioSource.PlayClipAtPoint(_as.clip, randomVec, _as.volume);
                }
                else
                    _as.Play();
            }
        }
    }

    public void playRandomLoop()
    {
        StartCoroutine("startRandomLoop");
    }

    private IEnumerator startRandomLoop ()
    {
        while (true)
        {
            yield return new WaitUntil(() => !_as.isPlaying);
            if (loopTimeMax != 0)
            {
                yield return new WaitForSeconds(Random.Range(loopTimeMin, loopTimeMax));
            }
            playRandom();
        }
    }

    public void stop()
    {
        StopAllCoroutines();
        _as.Stop();
    }
}
