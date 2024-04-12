using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public Transform ZombieClone;
    int NumberOfZombies = 10;

    private int zombieKilled = 0;
    List<ZombieHealth> allZombies=new List<ZombieHealth>();

    // Start is called before the first frame update
    void Start()
    {   
        for(int i = 0;i < NumberOfZombies; i++)
        {

            spawnNewZombie();

        }
    }

    private Vector3 getZombieLocation()
    {
        return new Vector3(UnityEngine.Random.Range(-100f, 100f), 0, UnityEngine.Random.Range(-100f, 100f));
    }

    public void ZombieKilled()
    {
        zombieKilled++;
        Debug.Log("Zombies Killed: " + zombieKilled);
        if (zombieKilled >= 10)
        {
            Debug.Log("Congratulations! You Win");
            Application.Quit();
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
