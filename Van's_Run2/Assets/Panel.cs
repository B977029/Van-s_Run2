using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject Stage1_Panel;
    public GameObject Stage2_Panel;

    public GameObject Sign_Panel;
    public GameObject Map_Panel;

    public GameObject State_Panel;

    // Start is called before the first frame update
    void Start()
    {
        Stage1_Panel = GameObject.Find("Stage1_Panel");
        Stage2_Panel = GameObject.Find("Stage2_Panel");
        Sign_Panel = GameObject.Find("Sign_Panel");
        Map_Panel = GameObject.Find("Map_Panel");
        State_Panel = GameObject.Find("State_Panel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.Panel1_on == true)
            Stage1_Panel.SetActive(true);
        else
            Stage1_Panel.SetActive(false);
       
        if (Player.Panel2_on == false)
            Stage2_Panel.SetActive(false);
        else
            Stage2_Panel.SetActive(true);

        if (Player.Sign_on == true)
            Sign_Panel.SetActive(true);
        else 
            Sign_Panel.SetActive(false);

        if (Player.Map_on == true)
        {
            Map_Panel.SetActive(true);
            Sign_Panel.SetActive(false);
        }
        else
            Map_Panel.SetActive(false);

        if (Player.State_on == true)
            State_Panel.SetActive(true);
        else
            State_Panel.SetActive(false);
    }
}
