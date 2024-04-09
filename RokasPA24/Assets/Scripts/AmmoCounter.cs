using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public int maxAmmo = 30; 
    public int ammo;
    public bool isFiring;
    public Text ammoDisplay;
    public float reloadDelay = 1.0f;
    void Start()
    {
       
        ammo = maxAmmo; 
    }

    void Update()
    {
        ammoDisplay.text = ammo.ToString();
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isFiring && ammo > 0)
        {
            isFiring = true;
            ammo--;
            isFiring = false;
        }
    }

    IEnumerator ReloadWithDelay()
    {
        
        yield return new WaitForSeconds(reloadDelay);

        
        ammo = maxAmmo;
    }
}

