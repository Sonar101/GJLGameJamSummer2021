using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfTentaclesBehavior : MonoBehaviour
{
    public Transform Player;
    public float maxDistance = 1;
    public float slowSpeed = 0.001f;
    public float maxSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        
        
        //Vector3 dist = Player.position - transform.position;
        if (Vector2.Distance(Player.position, transform.position) < maxDistance)
        {
            position.y += slowSpeed;
            transform.position = position;
        }
        else if(Vector2.Distance(Player.position, transform.position) > maxDistance)
        {
            position.y += maxSpeed;
            transform.position = position;
        }
    }
}
