using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AkAnimator : MonoBehaviour
{
    Animator AkAnimators;

    public AudioSource firingSound;
    public AudioSource reloadingSound;

    // Start is called before the first frame update
    void Start()
    {
        AkAnimators = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AkAnimators.SetBool("isReload", false);
        AkAnimators.SetBool("isFiring", false);

        firingSound.Stop();
        reloadingSound.Stop();

        if (Input.GetKey(KeyCode.R))
        {
            AkAnimators.SetBool("isReload", true);
            reloadingSound.Play();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            AkAnimators.SetBool("isFiring", true);
            firingSound.Play();
        }
    }
}
