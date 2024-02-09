using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float walkingspeed = 3f;
    float runningspeed = 5f;
    float crouchspeed = 2f;
    Animator PlayerAnimator;


    float lookingspeed = 2f;
    private bool isCrouching;
    private Vector3 orignalCenter;
    private float orignalHeight;
    private float originalMoveSpeed;


    void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        transform.tag = "Player";
        orignalCenter = transform.localPosition;
        orignalHeight = transform.localScale.y;
        originalMoveSpeed = walkingspeed;
        


    }

    // Update is called once per frame
    void Update()
    {


        PlayerAnimator.SetBool("isWalking", false);
        PlayerAnimator.SetBool("isInspect", false);

        PlayerAnimator.SetBool("isReload", false);
        PlayerAnimator.SetBool("isFire", false);
        PlayerAnimator.SetBool("isAim", false);




        if (Input.GetKey(KeyCode.W))
        {
            transform.position += walkingspeed * transform.forward * Time.deltaTime;
            PlayerAnimator.SetBool("isWalking", true);

        }




        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= walkingspeed * transform.forward * Time.deltaTime;
            PlayerAnimator.SetBool("isWalking", true);

        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.position += walkingspeed * transform.right * Time.deltaTime;
            PlayerAnimator.SetBool("isWalking", true);


        }



        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= walkingspeed * transform.right * Time.deltaTime;
            PlayerAnimator.SetBool("isWalking", true);

        }



        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += runningspeed * transform.forward * Time.deltaTime;
            PlayerAnimator.SetBool("isRunning", true);

        }

        else
        {
            PlayerAnimator.SetBool("isRunning", false);

        }

        if (Input.GetKey(KeyCode.F))
        {
            PlayerAnimator.SetBool("isInspect", true);
        }


        if (Input.GetKey(KeyCode.R))
        {
            PlayerAnimator.SetBool("isReload", true);


        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAnimator.SetBool("isFire", true);
            Ray gunshot = new Ray(transform.position, transform.forward);
            Debug.DrawRay(gunshot.origin, gunshot.direction * 50, Color.red, 5);
            if (Physics.Raycast(gunshot, 50))
                print("I hit something");


        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            PlayerAnimator.SetBool("isAim", true);
        }

       /* if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.position = Vector3.down * 1f;
            transform.position += crouchspeed*T
            
        }*/



    }
}