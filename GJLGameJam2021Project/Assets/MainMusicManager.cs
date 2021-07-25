using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicManager : MonoBehaviour
{
    GameObject musicPlayer;

    private void Awake()
    {
        musicPlayer = GameObject.Find("MUSIC");
        if(musicPlayer == null)
        {
            musicPlayer = gameObject;
            musicPlayer.name = "MUSIC";
            DontDestroyOnLoad(musicPlayer);
        }
        else
        {
            if (gameObject.name != "MUSIC")
            {
                Destroy(gameObject);
            }
        }
    }
}
