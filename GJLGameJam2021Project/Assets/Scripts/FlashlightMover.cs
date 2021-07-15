using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public GameObject flashlight;
    public float flashLightDistance = 10f;
    public bool makeMouseInvisible = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        if (makeMouseInvisible) Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Position flashlight
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0);
        Vector3 mouseDirClamp = Vector3.ClampMagnitude(mouseDir, flashLightDistance);

        flashlight.transform.localPosition = mouseDirClamp;

        // Flip player sprite based on flashlight position
        sr.flipX = ((flashlight.transform.localPosition - transform.position).normalized.x >= 0);

        // Rotate flashlight
        Vector2 mouseDirNorm = new Vector2(mouseDir.x, mouseDir.y).normalized;
        flashlight.transform.rotation = RotateToDirection(mouseDirNorm);
    }

    Vector2 GetMouseWorldSpaceDirection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos - transform.position;
    }

    Vector2 GetMouseScreenSpaceDirection()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 direction = mousePos - screenCenter;
        return direction;
    }

    private Quaternion RotateToDirection(Vector2 direction)
    {
        Quaternion rot = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.up, direction));
        return rot;
    }
}
