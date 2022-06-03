using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject exitButton;
    public GameObject settingsButton;
    public GameObject settingsImage;


    void Start()
    {
        settingsImage.SetActive(false);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
        playButton.SetActive(true);

    }

   
    void Update()
    {
        
    }

    public void ExitGame()
    {
        Debug.Log("Quite tiklandi");
        Application.Quit();
    }
    public void PlayButton()
    {
        Debug.Log("Play butona tiklandi");
        SceneManager.LoadScene(1);
    }
    public void SettingsButton()
    {
        Debug.Log("Settings butona tiklandi");
        settingsImage.SetActive(true);
        settingsButton.SetActive(false);
        exitButton.SetActive(false);
        playButton.SetActive(false);
    }
    public void SettingsExitButton()
    {
        settingsImage.SetActive(false);
        settingsButton.SetActive(true);
        exitButton.SetActive(true);
        playButton.SetActive(true);
    }
}
