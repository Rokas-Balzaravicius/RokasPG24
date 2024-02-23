using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
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

    internal enum characterHeight { upright, crouching }
    internal characterHeight currentlyIAm = characterHeight.upright;
    private float crouchingHeight =0.5f;
    private float uprightHeight = 1.0f;

    private int health = 100;

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


        if (Input.GetKey(KeyCode.LeftControl))
            currentlyIAm = characterHeight.crouching;
        else
            currentlyIAm = characterHeight.upright;



        switch (currentlyIAm)
        {
           
            case characterHeight.upright:



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

                setUprightHeight();
                break;

            case characterHeight.crouching:


                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += crouchspeed * transform.forward * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);

                }




                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= crouchspeed * transform.forward * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);

                }


                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += crouchspeed * transform.right * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);


                }



                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= crouchspeed * transform.right * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);

                }

                setCrouchingHeight();

                break;
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
                if(Physics.Raycast(gunshot, out RaycastHit hit))
                {
                    hit.collider.gameObject.GetComponent<ZombieHealth>()?.takeDamage(15);
                }
                print("I hit something");


        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            PlayerAnimator.SetBool("isAim", true);
        }

      



    }

    private void setCrouchingHeight()
    {
      transform.position = new Vector3(transform.position.x, crouchingHeight, transform.position.z);
    }

    private void setUprightHeight()
    {
        transform.position = new Vector3(transform.position.x, uprightHeight, transform.position.z);
    }

   public void takeDamage(int damage)
    {
        health -= damage;

        if (health < 0) { Destroy(gameObject); }
        print("My Health is now " + health.ToString());
    }










    public void ExitGame() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


}