using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfTentaclesBehavior : MonoBehaviour
{
    public Transform Player;
    public float maxDistance = 1;
    public float slowSpeed = 0.001f;
    public float finalStretchSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        
        position.y += slowSpeed;
        transform.position = position;

        if (Player.position.y >= -15f)
        {
            position.y += finalStretchSpeed;
            transform.position = position;
        }
    }
}
