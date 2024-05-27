using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public GameObject Board;
    bool start;
    public bool check = false;
    public static bool stay = true;

    private AudioSource bgm;
    public AudioClip ButtonSound;

    // Start is called before the first frame update
    void Start()
    {
        if (stay == true)
        {
            Board.SetActive(false);
            stay = false;
        }

        start = true;

        this.bgm = this.gameObject.AddComponent<AudioSource>();
        this.bgm.clip = this.ButtonSound;
    }

    // Update is called once per frame
    void Update()
    {
        if(start == true)
        {
            Board.SetActive(false);
            start = false;
        }
     
    }

    public void OnClickStart()
    {
        this.bgm.Play();
        SceneManager.LoadScene("Main");
    }

    public void OnClickTutorial()
    {
        this.bgm.Play();
        Board.SetActive(true);
        check = true;
    }

    public void OnClickExit()
    {
        this.bgm.Play();
        Application.Quit();
    }

    public void OnClickX()
    {
        Board.SetActive(false);
        check = false;
    }
}
