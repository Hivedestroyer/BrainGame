using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void startButton()
    //to be used to change scene on start button press
    {
        SceneManager.LoadScene("GameplayScene");

    }

    public void exitButton()
     //to be used to exit game on exit button press
    {
        Application.Quit();
    }
}
