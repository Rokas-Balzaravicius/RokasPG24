using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController :AIController

{
  
    
    // Start is called before the first frame update
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    void Start()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
    {
        maxMeleeDistance = 3f;
        breakAwayDistance = 8f;
        chaseSpeed = 1.5f;
        patrolChangeDirectionTime = 6f;
        patrolSpeed = 0.5f;
        AttackCoolDown = 2.5f;

        

        base.Start();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
}
