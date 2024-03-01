using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAnimator : MonoBehaviour
{

    Animator Pistolanimator;
    // Start is called before the first frame update
    void Start()
    {
        Pistolanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Pistolanimator.SetBool("isReloadPistol", false);
        Pistolanimator.SetBool("isFiringPistol", false);

        if (Input.GetKey(KeyCode.R))
        {
            Pistolanimator.SetBool("isReloadPistol", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pistolanimator.SetBool("isFiringPistol", true);
        }
    }
}
