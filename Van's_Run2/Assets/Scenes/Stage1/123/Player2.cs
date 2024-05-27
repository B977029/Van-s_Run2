using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player2 : MonoBehaviour
{
    public float jumpPower = 2.5f;
    public float point = 0.0f;
    public bool point_check = false;
    public bool jump_check = false;
    public bool grounded = true;
    public static bool atk = false;
    public bool hit = false;

    public float speed = 5.0f;

    public float rotationSpeed = 360.0f;

    public int heart = 3;
    public bool heart_check = false;

    CharacterController characterController;
    Animator animator;
    Vector3 direction;

    public Slider slider;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public static bool Stage1_clear = false;

    public bool die = false;

    public float time;
    public float time2;

    private AudioSource musicplayer;
    public bool hit_check = false;

    public static bool hit_sound = false;
    public static bool die_sound = false;
    public static bool potion_sound = false;
    public static bool key_sound = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        jumpPower = 2.5f;
        point = 0.0f;
        point_check = false;
        jump_check = false;
        grounded = true;
        atk = false;
        hit = false;
        heart = 3;
        speed = 5.0f;
        heart_check = false;
        die = false;
        time = 0;
        musicplayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die == false)
        {
            if (Slime.hit == true && hit_check == false) hit = true;
            else hit = false;

            if (hit == false)
            {
                heart_check = false;
                animator.SetBool("Hit", false);
            }

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
                playSound(musicplayer);
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

            if (Input.GetKeyDown(KeyCode.Z) && atk == false)
            {
                animator.SetBool("Atk", true);
                atk = true;
            }
            if (atk == true && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) { }
            else
            {    
                animator.SetBool("Atk", false);
                atk = false;
            }

            if (hit == true)
            {
                if (heart <= 1)
                {
                    animator.SetBool("Die", true);
                    hit = false;
                    die = true;
                    heart = 0;
                    heart_check = false;
                    die_sound = true;
                }
                animator.SetBool("Hit", true);
            }

            if (hit == true && (time2 <= 1))
            {

                if (heart < 1)
                {
                    animator.SetBool("Die", true);
                    hit = false;
                    die = true;
                    heart_check = false;
                    die_sound = true;
                    heart = 0;
                }

                hit = false;

                if (hit_check == false)
                {
                    heart -= 1;
                    hit_check = true;
                    hit_sound = true;
                }

            }

            if (hit_check == true)
            {
                if (heart < 1)
                {
                    animator.SetBool("Die", true);
                    hit = false;
                    die = true;
                    heart_check = false;
                    die_sound = true;
                    heart = 0;
                }

                time2 += Time.deltaTime;
            }
        
            if (time2 > 1)
            {
                hit_check = false;
                heart_check = true;
                time2 = 0;
                animator.SetBool("Hit", false);
            }
     
            if (heart == 3)
            {
                heart3.SetActive(true);
                heart2.SetActive(true);
                heart1.SetActive(true);
                speed = 5.0f;
            }

            if (heart == 2)
            {
                heart3.SetActive(false);
                heart2.SetActive(true);
                heart1.SetActive(true);
                speed = 9.0f;
            }

            if (heart == 1)
            {
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(true);
                speed = 13.0f;
            }

            if (heart <= 0)
            {
                heart3.SetActive(false);
                heart2.SetActive(false);
                heart1.SetActive(false);
            }
        }
        else if (die == true)
        {
            time += Time.deltaTime;

            if ( time > 1)
            {
                SceneManager.LoadScene("Fail");
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Goal1")
        {
            Stage1_clear = true;
            SceneManager.LoadScene("Success");
        }

        if (other.gameObject.name == "Goal2")
        {
            SceneManager.LoadScene("Success");
        }

        if (other.gameObject.name == "Key")
        {
            Player.Key_on = true;
            key_sound = true;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hp")
        {
            if (heart < 3)
            {
                heart += 1;
            }

            /*if (heart <= 0)
            {
                heart = 1;
            }*/
            potion_sound = true;
            Destroy(other.gameObject);
        }
    }

    public static void playSound(AudioSource audioPlayer)
    {
        audioPlayer.Stop();
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
}



