using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainUI : MonoBehaviour
{
   

    public void OnStartHereButtonClick()
    {
       // FindObjectOfType<Audiomanager>().Play("StartButton");
        SceneManager.LoadScene(1);
    }

    public void onContinueButtonClick()
    {
        SceneManager.LoadScene(4);
    }

    public void onExitButtonClick()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void onRestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void onPlayButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void onContButtonClick()
    {
        SceneManager.LoadScene(2);
    }

   
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
