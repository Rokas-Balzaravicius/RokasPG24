using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAnimator : MonoBehaviour
{

    Animator Pistolanimator;

    public AudioSource firingSound;
    public AudioSource reloadingSound;
    // Start is called before the first frame update
    void Start()
    {
        Pistolanimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Pistolanimator.SetBool("isReload", false);
        Pistolanimator.SetBool("isFiring", false);

        firingSound.Stop();
        reloadingSound.Stop();

        if (Input.GetKey(KeyCode.R))
        {
            Pistolanimator.SetBool("isReload", true);
            reloadingSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Pistolanimator.SetBool("isFiring", true);
            firingSound.Play();
        }
    }
}
