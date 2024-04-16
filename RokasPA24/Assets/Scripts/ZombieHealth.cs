using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour,HealthScript
{
    private int health = 100;

    ResourceManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            manager.IvDied(this);
            Destroy(gameObject);
        }
    }

    internal void Iam(ResourceManager resourceManager)
    {
       manager = resourceManager;
    }
}
