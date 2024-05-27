using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour
{
    Animator animator;
    public bool die = false;
    public bool check = false;
    private float time;
    public int currentTime;

    public static bool hit = false;
    public bool hit_check = false;
    public bool die_check = false;
    public bool first = false;

    private AudioSource musicplayer;
    public GameObject target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        die = false;
        check = false;
        time = 0;
        currentTime = 0;
        hit = false;
        hit_check = false;
        die_check = false;
        musicplayer = GetComponent<AudioSource>();
        first = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitbox.kill == true) check = true;
        else check = false;
        if (die == true)
        {
            if (first == false)
            {
                Player2.playSound(musicplayer);
                first = true;
            }
            hit = false;
            hit_check = false;
            die_check = true;
            agent.isStopped = true;
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) {}
            else
            {
                time += Time.deltaTime;
                currentTime = (int)time;
                if (currentTime >= 3)
                {
                    Destroy(this.gameObject);
                }
            }
        }

        if (this.gameObject.transform.position.z - target.transform.position.z <= 25 && die_check == false )
        {
            agent.destination = target.transform.position;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "End Line")
        {
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player_Hitbox" && die == false)
        {
            hit = true;
            hit_check = true;
        }
        
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            if (check == true && die == false)
            {
                die = true;
                animator.SetBool("die", true);
            }
        }

        if (other.gameObject.tag == "Player_Hitbox" && die == false)
        {
            hit = true;
            hit_check = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player_Hitbox")
        {
            hit = false;
            hit_check = false;
        }
    }
}
