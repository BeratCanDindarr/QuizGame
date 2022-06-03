using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//sorularımızın türlerini belirttigi yer
[System.Serializable]
public class QuestionAndAnswer 
{
    public AudioClip audio;
    public Sprite image;
    public string Question;
    public string[] Answer;
    public int CorrectAnswer;
}
