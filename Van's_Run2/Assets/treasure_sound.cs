using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasure_sound : MonoBehaviour
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
        if (Player.treasure_sound == true)
        {
            Player2.playSound(musicplayer);
            check = true;
            Player.treasure_sound = false;
        }

        else
            check = false;
    }
}