using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //connect tentacle tip to an invisible object that moves around inside a circle
    }

    // Update is called once per frame
    void Update()
    {
        
        //check distance of player and tentacle tip

        //player is 500 pixels away from tentacles tip and not attacking
            //tentacle moves around randomly

        //player is less than 500 pixels from the tentacle and not attacking
            //tentacle starts approaching player

        //tentacle is 100 or 50 from player
            //start wind up attack and must finish it before returning to check if the player has gotten far.


    }
}
