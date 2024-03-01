using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public Transform treeCloneTemplate;
    int NUMBER_OF_TREES = 100;

    public Transform ZombieClone;
    int NumberOfZombies = 10;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < NUMBER_OF_TREES; i++) 
        {
            Instantiate(treeCloneTemplate, getTreeSpawnLocation(), Quaternion.identity);
        }

        for(int i = 0;i < NumberOfZombies; i++)
        {
            Instantiate(ZombieClone, getZombieLocation(), Quaternion.identity);
        }
    }

    private Vector3 getZombieLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-200f, 200f), 0, UnityEngine.Random.Range(-100f, 100f));
    }

    private Vector3 getTreeSpawnLocation() 
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-50f, 50f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
