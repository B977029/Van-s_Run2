using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public bool attack = false;
    public static bool kill = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player2.atk == true)
            attack = true;
        else attack = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (attack == true)
        {
            if (other.gameObject.tag == "Mob")
            {
                kill = true;
            }
        }
        else kill = false;



    }

}
