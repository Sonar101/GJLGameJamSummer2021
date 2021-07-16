using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 0.5f;
    public float maxDistance = 10.0f;
    public Transform Player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //connect tentacle tip to an invisible object that moves around inside a circle
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;

        //check distance of player and tentacle tip
        if (Vector2.Distance(Player.position, transform.position) < maxDistance)
        {
            /*
            float angle = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
            */
            //start heading towards player
            rb.velocity = displacement * speed;
            //transform.position += (displacement * speed * Time.deltaTime);
        }

        //player is 500 pixels away from tentacles tip and not attacking
        //tentacle moves around randomly

        //player is less than 500 pixels from the tentacle and not attacking
        //tentacle starts approaching player

        //tentacle is 100 or 50 from player
        //start wind up attack and must finish it before returning to check if the player has gotten far.


    }
}
