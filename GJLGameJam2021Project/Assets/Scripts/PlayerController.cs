using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    public int curPlayerHealth = 0;

    public float maxFlashlightCharge = 10;
    public float curFlashlightCharge = 0;

    public int maxFlareNum = 5;
    public int curFlareNum = 0;

    private const float timestep = 0.1f;

    private Movement moveController;
    private FlareThrowBehavior flareThrowBehavior;
    private FlashlightController flashlightController;

    Coroutine flashlightDrainCharge;

    // Start is called before the first frame update
    void Start()
    {
        curPlayerHealth = maxPlayerHealth;
        curFlashlightCharge = maxFlashlightCharge;
        curFlareNum = maxFlareNum;

        moveController = GetComponent<Movement>();
        flareThrowBehavior = GetComponent<FlareThrowBehavior>();
        flashlightController = GetComponentInChildren<FlashlightController>();
    }

    void Update()
    {
        Vector2 moveDirection = GetInputDirection();

        if (moveDirection != Vector2.zero)
            moveController.Accelerate(moveDirection);

        if (Input.GetMouseButtonDown(0) && curFlareNum > 0)
        {
            flareThrowBehavior.ThrowFlare(GetMouseDirection());
            curFlareNum--;
            // some sort of update UI function...
        }

        if (Input.GetKeyDown(KeyCode.Space) && curFlashlightCharge > 0)
        {
            if(flashlightController.ToggleFlashlight())
                flashlightDrainCharge = StartCoroutine(DrainCharge());
            else
                StopCoroutine(flashlightDrainCharge);
        }
    }

    Vector2 GetMouseDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos - transform.position;
    }

    Vector2 GetInputDirection()
    {
        Vector2 moveDirection = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
            moveDirection.x += 1;

        if (Input.GetKey(KeyCode.A))
            moveDirection.x -= 1;

        if (Input.GetKey(KeyCode.W))
            moveDirection.y += 1;

        if (Input.GetKey(KeyCode.S))
            moveDirection.y -= 1;

        return moveDirection;
    }

    IEnumerator DrainCharge()
    {
        while (true)
        {
            yield return new WaitForSeconds(timestep);

            curFlashlightCharge -= timestep;
            flashlightController.SetProgress(curFlashlightCharge / maxFlashlightCharge);

            if (curFlashlightCharge <= 0)
            {
                flashlightController.DisableFlashlight();
                yield break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Flare" && curFlareNum < 5)
        {
            curFlareNum += 1;
            Destroy(collision.gameObject);
        }
    }

}
