using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxPlayerHealth = 100;
    protected int curPlayerHealth = 0;

    public float maxFlashlightCharge = 1f;
    protected float curFlashlightCharge = 0f;

    public int maxFlareNum = 5;
    protected int curFlareNum = 0;

    private Movement moveController;
    private FlareThrowBehavior flareThrowBehavior;

    // Start is called before the first frame update
    void Start()
    {
        curPlayerHealth = maxPlayerHealth;
        curFlashlightCharge = maxFlashlightCharge;
        curFlareNum = maxFlareNum;

        moveController = GetComponent<Movement>();
        flareThrowBehavior = GetComponent<FlareThrowBehavior>();
    }

    void FixedUpdate()
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
}
