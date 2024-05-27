using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;

    public float offsetx = 25f;
    public float offsety = 1f;
    public float offsetz = 3f;

    Vector3 cameraPsoition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPsoition.x = player.transform.position.x + offsetx;
        cameraPsoition.y = player.transform.position.y + offsety;
        cameraPsoition.z = player.transform.position.z + offsetz;

        transform.position = cameraPsoition;
    }
}
