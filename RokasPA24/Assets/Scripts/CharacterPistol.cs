using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPistol : MonoBehaviour
{

    Animator chPistol;
    // Start is called before the first frame update
    void Start()
    {
        chPistol = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        chPistol.SetBool("IsReloadPistolCh", false);
        chPistol.SetBool("IsFiringPistolCh", false);
        chPistol.SetBool("IsAimingPistol", false);
        chPistol.SetBool("IsInspectPistol", false);


        if (Input.GetKey(KeyCode.R))
        {
            chPistol.SetBool("IsReloadPistolCh", true);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            chPistol.SetBool("IsFiringPistolCh", true);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            chPistol.SetBool("IsAimingPistol", true);
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            chPistol.SetBool("IsInspectPistol", true);
        }
    }
}
