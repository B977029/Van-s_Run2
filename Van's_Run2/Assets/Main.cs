using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject Treewall;
    public GameObject State_Crystal;

    // Start is called before the first frame update
    void Start()
    {
        Treewall = GameObject.Find("Treewall");
        State_Crystal = GameObject.Find("State_Crystal");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player2.Stage1_clear == false)
            Treewall.SetActive(true);
        else
            Treewall.SetActive(false);

        if (Player.State_Crystal_on == false)
            State_Crystal.SetActive(false);
        else if (Player.State_Crystal_on == true)
            State_Crystal.SetActive(true);
    }
}
