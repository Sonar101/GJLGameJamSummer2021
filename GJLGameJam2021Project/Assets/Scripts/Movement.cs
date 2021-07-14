using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // variables
    private Rigidbody2D rb;
    public float acceleration = 0.05f;
    public float maxMoveSpeed = 1f;
    public float rotSpeed = 2.5f;
        
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity += GetInputAcceleration();

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxMoveSpeed);

        if(Vector2.SqrMagnitude(rb.velocity) > 0.01)
            transform.rotation = RotateToDirection(rb.velocity);
    }

    private Quaternion RotateToDirection(Vector2 direction)
    {
        Quaternion rot = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, direction));
        return Quaternion.Slerp(transform.rotation, rot, rotSpeed * Time.deltaTime);
    }

    private Vector2 GetInputAcceleration()
    {
        Vector2 accelVec = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.D))
        {
            accelVec.x += acceleration;
        }
        if (Input.GetKey(KeyCode.A))
        {
            accelVec.x -= acceleration;
        }

        if (Input.GetKey(KeyCode.W))
        {
            accelVec.y += acceleration;
        }
        if (Input.GetKey(KeyCode.S))
        {
            accelVec.y -= acceleration;
        }

        return Vector2.ClampMagnitude(accelVec, acceleration);
    }
}
