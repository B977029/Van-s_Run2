using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float jumpPower = 2.0f;
    public float point = 0.0f;
    public bool point_check = false;
    public bool jump_check = false;
    public bool grounded = true;

    public float speed = 10.0f;

    public float rotationSpeed = 360.0f;

    CharacterController characterController;
    Animator animator;
    Vector3 direction;

    public static bool Panel1_on = false;
    public static bool Panel2_on = false;
    public static bool Sign_on = false;
    public static bool Map_on = false;
    public static bool State_on = false;

    public static bool Key_on = false;
    public bool Crystal_on = false;
    public static bool State_Crystal_on = false;

    public GameObject Storm;

    public static bool End_on = false;

    public static bool treasure_sound = false;

    private AudioSource musicplayer;

    public bool Wind_on = false;
    public static bool Wind_sound = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        musicplayer = GetComponent<AudioSource>();
        jumpPower = 2.0f;
        point = 0.0f;
        point_check = false;
        jump_check = false;
        grounded = true;

        speed = 10.0f;
}

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
            transform.forward,
            direction,
            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction)
            );
            transform.LookAt(transform.position + forward);
        }

        if (Input.GetKeyDown(KeyCode.X) && grounded == true)
        {
            point = 0.0f;
            point_check = true;
            grounded = false;
            Player2.playSound(musicplayer);
        }

        if (point_check == true)
            point += 10.0f * Time.deltaTime;

        direction.y = point;
        characterController.Move(direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", characterController.velocity.magnitude);

        if (jump_check == true || (characterController.isGrounded == false && point_check == false))
            point -= 11.0f * Time.deltaTime;

        if (point >= jumpPower)
        {
            jump_check = true;
            point_check = false;
        }
        if (characterController.isGrounded == true)
        {
            point = 0;
            jump_check = false;
            point_check = false;
            grounded = true;
        }

        if (Panel1_on == true)
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Stage1");
                Panel1_on = false;
            }

        if (Panel2_on == true)
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Stage2");
                Panel2_on = false;
            }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Sign_on == true)
                Map_on = true;

            if (State_on == true)
            {
                if (Crystal_on == true)
                {  
                    State_Crystal_on = true;
                    Destroy(Storm);
                }
            }
        }

        if (Wind_on)
            Wind_sound = true;

        else Wind_sound = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Stage1")
            Panel1_on = true;

        if (other.gameObject.name == "Stage2")
            Panel2_on = true;

        if (other.gameObject.name == "Sign_Trigger")
            Sign_on = true;

        if (other.gameObject.name == "Treasure")
            if (Key_on == true)
            {
                treasure_sound = true;

                Destroy(other.gameObject);
            }

        if (other.gameObject.name == "Crystal")
        {      
            Crystal_on = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "State_Trigger")
            State_on = true;

        if (other.gameObject.name == "Door")
            SceneManager.LoadScene("Ending");

        if (other.gameObject.name == "Storm_Zone")
            Wind_on = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Stage1")
            Panel1_on = false;

        if (other.gameObject.name == "Stage2")
            Panel2_on = false;

        if (other.gameObject.name == "Sign_Trigger")
            Sign_on = false;
            Map_on = false;

        if (other.gameObject.name == "State_Trigger")
        {
            State_on = false;
        }

        if (other.gameObject.name == "Storm_Zone")
        {
            Wind_on = false;
        }
    }
}
