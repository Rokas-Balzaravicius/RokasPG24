using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PlayerMovement : MonoBehaviour,HealthScript
{
    private float walkingspeed = 3f;
    private float runningspeed = 5f;
    private float crouchspeed = 2f;
    Animator PlayerAnimator;

    RuntimeAnimatorController ARAnimator, PistolAnimator;
    
    internal enum characterHeight { upright, crouching }
    internal characterHeight currentlyIAm = characterHeight.upright;
    private float crouchingHeight =0.5f;
    private float uprightHeight = 1.0f;

    private int health = 100;

    AmmoCounter ammoCounter;

    bool canFireRaycast = true;
    public float reloadDelay = 1.0f;

    public AudioSource walkingSound;
    public AudioSource runningSound;
    

    void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();

        ARAnimator =(RuntimeAnimatorController) Resources.Load("PLayerAnimator");

        PistolAnimator = (RuntimeAnimatorController)Resources.Load("CharacterPistol");


        PlayerAnimator.runtimeAnimatorController = ARAnimator;

        updateAmmoScript();

    }

    // Update is called once per frame
    void Update()
    {

        //Weapon Animator Swap

        if(Input.GetKeyDown("1"))
        {
            PlayerAnimator.runtimeAnimatorController = ARAnimator;
        }

        if(Input.GetKeyDown("2"))
        {
            PlayerAnimator.runtimeAnimatorController = PistolAnimator;
        }




        //Character Controlls 

        walkingSound.Stop();
        runningSound.Stop();
       

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
                    walkingSound.Play();

                }




                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= walkingspeed * transform.forward * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();

                }


                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += walkingspeed * transform.right * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();


                }



                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= walkingspeed * transform.right * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();

                }

                setUprightHeight();
                break;

            case characterHeight.crouching:


                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += crouchspeed * transform.forward * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();

                }




                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= crouchspeed * transform.forward * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();

                }


                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += crouchspeed * transform.right * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();


                }



                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= crouchspeed * transform.right * Time.deltaTime;
                    PlayerAnimator.SetBool("isWalking", true);
                    walkingSound.Play();
                }

                setCrouchingHeight();

                break;
        }


   





        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += runningspeed * transform.forward * Time.deltaTime;
            PlayerAnimator.SetBool("isRunning", true);
            runningSound.Play();

        }

        else
        {
            PlayerAnimator.SetBool("isRunning", false);

        }




        //Weapon Funtions 


        if (Input.GetKey(KeyCode.F))
        {
            PlayerAnimator.SetBool("isInspect", true);
        }


        if (Input.GetKey(KeyCode.R))
        {
            PlayerAnimator.SetBool("isReload", true);
            StartCoroutine(ReloadWithDelay());
          

        }

        if (ammoCounter.ammo <= 0)
        {
            PlayerAnimator.SetBool("isFire", false);
            canFireRaycast = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && canFireRaycast)
        {
            PlayerAnimator.SetBool("isFire", true);
            FireRaycast();
            
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            PlayerAnimator.SetBool("isAim", true);
        }


       

      



    }

    IEnumerator ReloadWithDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        canFireRaycast = true;
        ammoCounter.ammo = ammoCounter.maxAmmo;
    }


    private void FireRaycast()
    {
        Ray gunshot = new Ray(transform.position, transform.forward);
        Debug.DrawRay(gunshot.origin, gunshot.direction * 50, Color.red, 5);   //<-- extending in the direction gunshot.direction,                                                                      
        if (Physics.Raycast(gunshot,50))                                       //multiplied by 50 units.
        {                                                                      //The ray is drawn for a duration of 5 seconds.
            if (Physics.Raycast(gunshot, out RaycastHit hit))
            {
                hit.collider.gameObject.GetComponent<ZombieHealth>()?.takeDamage(15);
            }
            print("I hit something");
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




   // This is an Interface from the Health Script
   public void takeDamage(int damage)
    {
        health -= damage;

        if (health < 0) { Destroy(gameObject); }
        print("My Health is now " + health.ToString());
    }



    //This is an Inheritance from the AmmoCounter Script
    public void updateAmmoScript()
    {
        ammoCounter = GetComponentInChildren<AmmoCounter>();

    }






    public void ExitGame() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quitting");
            Application.Quit();
        }
    }


}