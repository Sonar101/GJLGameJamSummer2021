using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private LevelManager lm;
    // Start is called before the first frame update
    void Start()
    {
        lm = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            lm.checkPoint = transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
