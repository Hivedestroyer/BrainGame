using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public AudioSource audioS;
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

        StartCoroutine(ExampleCoroutine());

    }

    public void exitButton()
     //to be used to exit game on exit button press
    {
        Application.Quit();
    }

    IEnumerator ExampleCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GameplayScene");

    }
}
