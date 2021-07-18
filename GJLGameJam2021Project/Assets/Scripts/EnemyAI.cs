using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed = 0.5f;
    public float maxDistance = 10.0f;
    // this accelaration is for the random movement
    public float acceleration = 2f;
    Vector2 movement;
    private float timeLeft;
    public Transform Player;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //connect tentacle tip to an invisible object that moves around inside a circle
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        timeLeft -= Time.deltaTime;

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
        //random movement when player is not close
        else if (Vector2.Distance(Player.position, transform.position) > maxDistance)
        {
            if (timeLeft <= 0)
            {
                movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                timeLeft += acceleration;
            }

        }
    }
    void FixedUpdate()
    {
        rb.AddForce(movement * speed);
    }

}
