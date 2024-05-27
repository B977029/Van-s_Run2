using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private AudioSource musicplayer;

    public float time;
    public static bool sound = false;
    public bool check = false;

    // Start is called before the first frame update
    void Start()
    {
        musicplayer = GetComponent<AudioSource>();
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    
        if (time >= 2.7)
        {
            if (check == false)
            {
                Player2.playSound(musicplayer);
                check = true;
            }
        }

        if (time >= 7)
        {
            time = 0;
            SceneManager.LoadScene("Final");
        }
    }
}
