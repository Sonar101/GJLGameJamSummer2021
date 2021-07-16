using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private SpriteRenderer flashlightSprite;
    public GameObject flashlight;
    public float jointDistanceFromBody = .3f;
    public float maxDistanceFromJoint = 10f;
    public bool makeMouseInvisible = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        flashlightSprite = flashlight.gameObject.GetComponentInChildren<SpriteRenderer>();
        if (makeMouseInvisible) Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate flashlight position 
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = new Vector3(mousePos.x - transform.position.x, mousePos.y - transform.position.y, 0);
        Vector3 mouseDirClamp = Vector3.ClampMagnitude(mouseDir, maxDistanceFromJoint);

        flashlight.transform.localPosition = mouseDirClamp;

        // Flip player sprite based on flashlight position
        print(mouseDirClamp);
        if (mouseDirClamp.x >= 0) {
            // facing right
            sr.flipX = true;
            flashlightSprite.flipX = true;
            flashlight.transform.localPosition += new Vector3(jointDistanceFromBody, 0, 0);
        }
        else
        {
            // facing left
            sr.flipX = false;
            flashlightSprite.flipX = false;
            flashlight.transform.localPosition -= new Vector3(jointDistanceFromBody, 0, 0);
        }

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
