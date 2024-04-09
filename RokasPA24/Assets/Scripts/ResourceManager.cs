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

    private int zombieKilled = 0;
    List<ZombieHealth> allZombies=new List<ZombieHealth>();

    // Start is called before the first frame update
    void Start()
    {   

        for(int i = 0; i < NUMBER_OF_TREES; i++) 
        {
           Instantiate(treeCloneTemplate, getTreeSpawnLocation(), Quaternion.identity);
        }

        for(int i = 0;i < NumberOfZombies; i++)
        {

            spawnNewZombie();

        }
    }

    private Vector3 getZombieLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-100f, 100f));
    }

    private Vector3 getTreeSpawnLocation() 
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-50f, 50f));
    }

    public void ZombieKilled()
    {
        zombieKilled++;
        Debug.Log("Zombies Killed: " + zombieKilled);
        if (zombieKilled >= 2)
        {
            Debug.Log("Congratulations! You Win");
            Application.Quit();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void IvDied(ZombieHealth zombieHealth)
    {
        ZombieKilled();
        spawnNewZombie();
    }

    private void spawnNewZombie()
    {
        Transform newZombieGO = Instantiate(ZombieClone, getZombieLocation(), Quaternion.identity);
        ZombieHealth newZombie = newZombieGO.GetComponent<ZombieHealth>();
        allZombies.Add(newZombie);
        newZombie.Iam(this);

    }
}
