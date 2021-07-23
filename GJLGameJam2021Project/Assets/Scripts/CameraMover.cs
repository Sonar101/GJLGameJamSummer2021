using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject cam;
    private Transform specialTargetTrans;
    private bool usingSpecialTarget = false;
    public float camTargetDistance = 200f;
    public float screenVecRatio = 50f;
    public float lerpRate = .02f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (!usingSpecialTarget)
            {
                Vector3 playerPos = transform.position;
                Vector2 mouseDir = GetMouseScreenSpaceDirection();
                Vector2 mouseDirClamp = Vector2.ClampMagnitude(mouseDir, camTargetDistance) / screenVecRatio;
                Vector3 camTarget = new Vector3(mouseDirClamp.x + playerPos.x, mouseDirClamp.y + playerPos.y, cam.transform.position.z);

                cam.transform.position = Vector3.Lerp(cam.transform.position, camTarget, lerpRate * Time.deltaTime);
            }
            else
            {
                Vector3 specialTarget = new Vector3(specialTargetTrans.position.x, specialTargetTrans.position.y, cam.transform.position.z);
                cam.transform.position = Vector3.Lerp(cam.transform.position, specialTarget, lerpRate * Time.deltaTime);
            }
        }
    }

    Vector2 GetMouseScreenSpaceDirection()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        Vector2 direction = mousePos - screenCenter;
        return direction;
    }

    public void ChooseAndUseSpecialTarget(Transform target)
    {
        specialTargetTrans = target;
        usingSpecialTarget = true;
    }

    public void ReturnToNormalTarget()
    {
        usingSpecialTarget = false;
    }

    public void setCamLerpRate(float value)
    {
        lerpRate = value;
    }
}
