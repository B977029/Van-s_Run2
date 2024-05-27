using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fail : MonoBehaviour
{
    private float time;
    public int currentTime;
    public bool state = false;
    public bool check = false;

    public GameObject pic1;
    public GameObject pic2;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        currentTime = (int)time;

        if (currentTime % 2 == 1)
        {
            check = true;
            state = true;
        }

        else
        {
            check = false;
            state = false;
        }

        if (state == true)
        {
            pic1.SetActive(true);
            pic2.SetActive(false);
        }

        if (state == false)
        {
            pic1.SetActive(false);
            pic2.SetActive(true);
        }

        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
