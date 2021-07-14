using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareThrowBehavior : MonoBehaviour
{
    public Rigidbody2D Flare;
    public float throwSpeed;

    public void ThrowFlare(Vector2 direction)
    {
        Rigidbody2D flare = Instantiate(Flare, transform.position, Quaternion.identity);
        flare.AddForce(direction.normalized * throwSpeed);
    }
}
