using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public Transform ZombieClone;
    int NumberOfZombies = 10;
    public Transform ZombieBoss;

    private int zombieKilled = 0;
    int zombiesKilledForBoss = 2;
    List<ZombieHealth> allZombies=new List<ZombieHealth>();

    private bool bossSpawned = false;

    public Transform TreeClone;
    int NoOfTrees = 500;

    

    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 0;i < NumberOfZombies; i++)
        {

            spawnNewZombie();

        }

        for(int i = 0; i < NoOfTrees; i++)
        {
            Instantiate(TreeClone,getTreeSpawnLocation(), Quaternion.identity);
        }
    }

    private Vector3 getZombieLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-100f, 100f));
    }

    private Vector3 getTreeSpawnLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-200f, 200f), 0, UnityEngine.Random.Range(-200f, 200));
    }

    public void ZombieKilled()
    {
        zombieKilled++;
        Debug.Log("Zombies Killed: " + zombieKilled);
        if (!bossSpawned && zombieKilled >= zombiesKilledForBoss)
        {
            Debug.Log("Boss Zombie Incoming");
            Transform newZombieGO = Instantiate(ZombieBoss,getZombieLocation(),Quaternion.identity);
            ZombieHealth newZombie = newZombieGO.GetComponent<ZombieHealth>();
            allZombies.Add(newZombie);
            newZombie.Iam(this);

            bossSpawned = true;
        }
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
