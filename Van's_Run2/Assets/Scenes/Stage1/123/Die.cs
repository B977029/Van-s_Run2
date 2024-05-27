using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
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
        if (Player2.die_sound == true)
        {
            Player2.playSound(musicplayer);
            check = true;
            Player2.die_sound = false;
        }

        else
            check = false;
    }
}