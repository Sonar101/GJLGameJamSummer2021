using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject cam;
    public float camTargetDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = GetMouseDirection();
        Vector3 mouseRelative = Vector2.ClampMagnitude(mousePos, camTargetDistance);
        print(mouseRelative);

        cam.transform.position = new Vector3(mouseRelative.x, mouseRelative.y, cam.transform.position.z);
        //cam.transform.position = new Vector3(transform.position.x, transform.position.y, cam.transform.position.z);
    }

    Vector2 GetMouseDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        return mousePos - transform.position;
    }
}
