using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
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
        if (Player2.atk == true)
        {
            Player2.playSound(musicplayer);
            check = true;
        }

        else
            check = false;
    }
}
