using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Application.Quit();
        print("Exiting game");


        
    }

    public void StartGame()
    {
        //Start Game
        SceneManager.LoadScene(1);
        print("Playing game");
    }



}
