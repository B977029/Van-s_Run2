using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hitbox : MonoBehaviour
{
    public static bool hit = false;
    public bool check = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Mob")
        {
            hit = true;
            check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Mob")
        {
            hit = false;
            check = false;
        }
    }
}
