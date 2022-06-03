using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    int levelUnlock;

    public Button[] buttons;
    public void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levelUnlock", 1);
        LevelUnlock();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUnlock()
    {
        
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i < buttons.Length)
            {
                buttons[i].interactable = false;
            }
        }
        for (int i = 0; i < levelUnlock; i++)
        {
            if (i < buttons.Length) { buttons[i].interactable = true; }
        }
    }
}
