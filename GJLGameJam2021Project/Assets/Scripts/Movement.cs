using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // variables
    private Rigidbody2D RB;
    public float acceleration = 0.05f;
        
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            RB.velocity += new Vector2(acceleration, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            RB.velocity += new Vector2(-acceleration, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RB.velocity += new Vector2(0, acceleration);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            RB.velocity += new Vector2(0, -acceleration);
        }
    }
}
