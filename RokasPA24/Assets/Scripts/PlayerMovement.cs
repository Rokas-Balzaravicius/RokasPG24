using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float walkingspeed = 3f;
    float runningspeed = 5f;
    Animator PlayerAnimator;
    void Start()
    {
        PlayerAnimator = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAnimator.SetBool("isWalking", false);

        if(Input.GetKey(KeyCode.W)) 
        {
            transform.position += walkingspeed * transform.forward * Time.deltaTime;
        }

        PlayerAnimator.SetBool("isWalking", true);

        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= walkingspeed * transform.forward * Time.deltaTime; 
        }

        if( Input.GetKey(KeyCode.D))
        {
            transform.position += walkingspeed * transform.right * Time.deltaTime;
        }

        if(Input .GetKey(KeyCode.A)) 
        {
            transform.position -= walkingspeed * transform.right * Time.deltaTime;
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

    }
}
