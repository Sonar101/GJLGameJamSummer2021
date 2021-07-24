using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidLightReveal : MonoBehaviour
{
    private CameraMover camMover;
    private PlayerController playerController;
    private Animator lightAnimator;
    public GameObject Player;
    public float panInDuration = 13f; // (in seconds)
    public float pauseDuration = 3f; // (in seconds)
    public float timeBeforePlayerControl = 10f; // (in seconds)
    public float cameraLerpRate = 0.01f;
    public GameObject shadowWall;
    
    // Start is called before the first frame update
    void Start()
    {
        camMover = Player.GetComponent<CameraMover>();
        playerController = Player.GetComponent<PlayerController>();
        lightAnimator = GetComponent<Animator>();
    }

    public void StartRevealCoroutine()
    {
        StartCoroutine(PerformLightOnlyReveal());
    }

    IEnumerator PerformFullCameraReveal()
    {
        // start panning towards the monster's eye
        playerController.setDeath(true);                                    // disable player controls
        camMover.ChooseAndUseSpecialTarget(transform);                      // change cam lerp target
        float ogLerpRate = camMover.lerpRate;                               // store the cam's old lerp rate
        camMover.setCamLerpRate(cameraLerpRate);                            // change cam lerp rate
        lightAnimator.SetBool("isLightingUp", true);                        // trigger light anim fade in
        yield return new WaitForSecondsRealtime(panInDuration);             // (after a delay)

        // fade out the light and wait briefly
        lightAnimator.SetBool("isLightingUp", false);                       // trigger light anim fade out
        yield return new WaitForSecondsRealtime(pauseDuration);             // (after a delay)

        // head back to the player's normal camera
        camMover.ReturnToNormalTarget();                                    // return lerp target to normal
        yield return new WaitForSecondsRealtime(timeBeforePlayerControl);   // (after a delay)

        // hand player full control back
        playerController.setDeath(false);                                   // return control to player
        camMover.setCamLerpRate(ogLerpRate);                                // return cam to original lerp rate
    }

    IEnumerator PerformLightOnlyReveal()
    {
        shadowWall.SetActive(false);
        lightAnimator.SetBool("isLightingUp", true);                        // trigger light anim fade in
        yield return new WaitForSecondsRealtime(panInDuration);             // (after a delay)
        lightAnimator.SetBool("isLightingUp", false);                       // trigger light anim fade out
        shadowWall.SetActive(true);
    }
}
