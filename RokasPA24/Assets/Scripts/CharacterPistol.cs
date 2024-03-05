using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class CharacterPistol : MonoBehaviour
{
    private float walkingspeed = 3f;
    private float runningspeed = 5f;
    private float crouchspeed = 2f;

    internal enum characterHeight { upright, crouching }
    internal characterHeight currentlyIAm = characterHeight.upright;
    private float crouchingHeight = 0.5f;
    private float uprightHeight = 1.0f;

    private int health = 100;

   
    Animator chPistol;
    // Start is called before the first frame update
    void Start()
    {
        chPistol = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        chPistol.SetBool("IsWalkingCh", false);
        chPistol.SetBool("IsRunningCh", false);

        chPistol.SetBool("IsReloadingPistolCh", false);
        chPistol.SetBool("IsFiringPistolCh", false);
        chPistol.SetBool("IsInspectPistol", false);









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
                    chPistol.SetBool("IsWalkingCh", true);

                }




                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= walkingspeed * transform.forward * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);

                }


                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += walkingspeed * transform.right * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);


                }



                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= walkingspeed * transform.right * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);

                }

                setUprightHeight();
                break;

            case characterHeight.crouching:


                if (Input.GetKey(KeyCode.W))
                {
                    transform.position += crouchspeed * transform.forward * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);

                }




                if (Input.GetKey(KeyCode.S))
                {
                    transform.position -= crouchspeed * transform.forward * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);

                }


                if (Input.GetKey(KeyCode.D))
                {
                    transform.position += crouchspeed * transform.right * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);


                }



                if (Input.GetKey(KeyCode.A))
                {
                    transform.position -= crouchspeed * transform.right * Time.deltaTime;
                    chPistol.SetBool("IsWalkingCh", true);

                }

                setCrouchingHeight();

                break;
        }


        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position += runningspeed * transform.forward * Time.deltaTime;
            chPistol.SetBool("IsRunningCh", true);

        }

        else
        {
            chPistol.SetBool("IsRunningCh", false);

        }

        if (Input.GetKey(KeyCode.R))
        {
            chPistol.SetBool("IsReloadingPistolCh", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            chPistol.SetBool("IsFiringPistolCh", true);
            Ray gunshot = new Ray(transform.position, transform.forward);
            Debug.DrawRay(gunshot.origin, gunshot.direction * 50, Color.red, 5);
            if (Physics.Raycast(gunshot, 50))
                if (Physics.Raycast(gunshot, out RaycastHit hit))
                {
                    hit.collider.gameObject.GetComponent<ZombieHealth>()?.takeDamage(10);
                }
            print("I hit something");
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            chPistol.SetBool("IsAimingPistol", true);
        }

        else
        {
            chPistol.SetBool("IsAimingPistol", false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            chPistol.SetBool("IsInspectPistol", true);
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

}
