using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
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
        if (Player2.key_sound == true)
        {
            Player2.playSound(musicplayer);
            check = true;
            Player2.key_sound = false;
        }

        else
            check = false;
    }
}