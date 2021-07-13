using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlareThrowBehavior : MonoBehaviour
{
    public Rigidbody2D Flare;
    public float throwSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowFlare(GetMouseDirection());
        }
    }

    Vector2 GetMouseDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos - transform.position;
    }

    private void ThrowFlare(Vector2 direction)
    {
        Rigidbody2D flare = Instantiate(Flare, transform.position, Quaternion.identity);
        flare.AddForce(direction.normalized * throwSpeed);
    }
}
