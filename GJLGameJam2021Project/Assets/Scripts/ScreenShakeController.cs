using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    private float shakeTimeRemaining, shakePower;
    private bool isScreenShaking = false;
    public AudioSource roarSFX;
    public float length = .5f;
    public float power = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isScreenShaking)
        {
            
            int rand = Random.Range(0, 500);
            if (LevelManager.current.GetBlackBoxBroken())
            {

                //print(rand);
                if (rand == 17)
                {
                    StartShake(length, power);
                    roarSFX?.Play();
                    StartCoroutine(checkingTime());
                }


            }
            
        }
       
        
        
        
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartShake(.5f, 1f);
        }
        */
    }
    private void LateUpdate()
    {
       if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0);
        }
    }
    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
    }
    private IEnumerator checkingTime()
    {
        isScreenShaking = true;
        // process pre-yield
        yield return new WaitForSeconds(10.0f);
        // process post-yield
        isScreenShaking = false;
    }
}
