using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelScript : MonoBehaviour
{
    public GameObject quizManager;
    public GameObject lLManager;
    public void Pass()
    {
        int currentlevel = quizManager.GetComponent<QuizManager>().level;

        if (currentlevel >= PlayerPrefs.GetInt("levelUnlock"))
        {
            PlayerPrefs.SetInt("levelUnlock", currentlevel + 1);
        }
        
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            PlayerPrefs.SetInt("levelUnlock", 1);
            Debug.Log("Level Sıfırlandı");
            lLManager.GetComponent<LevelManager>().Start();
        }
    }
}
