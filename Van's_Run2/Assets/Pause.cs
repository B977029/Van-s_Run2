using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject Panel;
    bool start;

    // Start is called before the first frame update
    void Start()
    {
        start = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(start)
        {
            Panel.SetActive(false);
            start = false;
        }
       
    }

    public void OnClickPause()
    {
        Time.timeScale = 0;
        Panel.SetActive(true);
    }

    public void OnClickResume()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickQuit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
