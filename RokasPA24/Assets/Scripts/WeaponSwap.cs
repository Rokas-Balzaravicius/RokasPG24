using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public GameObject AR;
    public GameObject P_LPSP_WEP_Handgun_04;
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Equip1();
        }

        if (Input.GetKeyDown("2")) 
        {
            Equip2();
        }

    }


    void Equip1()
    {
        AR.SetActive(true);
        P_LPSP_WEP_Handgun_04.SetActive(false);
        gameObject.SendMessage("updateAmmoScript");
    }

    void Equip2()
    {
        AR.SetActive(false);
        P_LPSP_WEP_Handgun_04.SetActive(true);
        gameObject.SendMessage("updateAmmoScript");
    }
}
