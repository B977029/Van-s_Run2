using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind_sound : MonoBehaviour
{
    private AudioSource musicplayer;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        musicplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Wind_sound == true)
        {
            if (musicplayer.isPlaying == false)
            {
                Player2.playSound(musicplayer);
                check = true;
            }
        }

        else
        {
            check = false;
            musicplayer.Stop();
        }

    }
}