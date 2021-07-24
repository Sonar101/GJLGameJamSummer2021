using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager current;
    public Vector2 checkPoint;

    public GameObject[] tentacles;
    public GameObject deathplane;
    public DeathplaneTrigger deathplaneTrigger;
    public Transform deathplanePosition;
    public GameObject resurfaceHitbox;
    public SquidLightReveal squidRevealObj;
    public GameObject leftInvisbleWallText;
    public GameObject rightInvisbleWallText;
    public GameObject leftInvisbleWallTextAfterBlackBox;
    public GameObject rightInvisbleWallTextAfterBlackBox;
    public FlareSpawner flareSpawner;

    public AudioSource roarSFX;
    public AudioSource pickupSFX;

    private GameObject deathplaneInstance;
    private bool blackBoxBroken = false;

    void Awake()
    {
        if(current == null)
        {
            current = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public event Action<int> onButtonPress;
    public void ButtonPress(int id)
    {
        if (onButtonPress != null)
            onButtonPress.Invoke(id);
    }

    public event Action onCloseAllDoors;
    public event Action onCameraRumble;
    public event Action onCloseAllSwitches;
    public void CloseAllDoors()
    {
        if (onCloseAllDoors != null)
            onCloseAllDoors();

        if (onCameraRumble != null)
            onCameraRumble();

        if (onCloseAllSwitches != null)
            onCloseAllSwitches();
    }

    public event Action onRespawnAllFlares;
    public void RespawnAllFlares()
    {
        if (onRespawnAllFlares != null)
            onRespawnAllFlares();
    }

    public void DestroyBlackBox()
    {
        blackBoxBroken = true;
        foreach (GameObject tentacle in tentacles)
        {
            tentacle.SetActive(true);
        }
        pickupSFX?.Play();
        roarSFX?.Play();
        squidRevealObj.StartRevealCoroutine();
        resurfaceHitbox.SetActive(true);
        leftInvisbleWallText.SetActive(false);
        rightInvisbleWallText.SetActive(false);
        leftInvisbleWallTextAfterBlackBox.SetActive(true);
        rightInvisbleWallTextAfterBlackBox.SetActive(true);
    }

    public event Action onTryInteract;
    public void TryInteract()
    {
        //Debug.Log("Manager Interact");
        if (onTryInteract != null)
            onTryInteract();
    }

    public event Action<Dialogue> onTriggerDialogue;
    public void TriggerDialogue(Dialogue dialogue)
    {
        if (onTriggerDialogue != null)
            onTriggerDialogue(dialogue);

        Debug.Log(dialogue.sentence);
    }

    public void DeathplaneTrigger()
    {
        deathplaneInstance = Instantiate(deathplane, deathplanePosition.position, Quaternion.identity);
    }

    public void DeathplaneReset()
    {
        Destroy(deathplaneInstance);
        deathplaneTrigger.resetTrigger();
    }

    public bool GetBlackBoxBroken()
    {
        return blackBoxBroken;
    }

    // --- Scene reload management
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        blackBoxBroken = false;
    }
}
