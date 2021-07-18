using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfTentaclesBehavior : MonoBehaviour
{
    public Transform Player;
    public float maxDistance = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        
        float dist = Player.transform.position.y - transform.position.y;
        if (dist < maxDistance)
        {
            position.y += 0.01f;
            transform.position = position;
        }
        else if(dist > maxDistance)
        {
            position.y += 0.02f;
            transform.position = position;
        }
    }
}
