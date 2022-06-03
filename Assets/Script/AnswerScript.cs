using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizmanager;

    public GameObject correctButtons;
    public GameObject wrongButtons;
    //sorular dogru veya yanlış oldugunda buraya geliyor burdan quizmanager daki dogruya veya yanlışa gönderiliyor
    public void Answer()
    {
        if (isCorrect)
        {
            quizmanager.CorrectAudio();
            Debug.Log("Correct Answer");
            GreenCorrectt();
            quizmanager.Correct();
           
        }
        else
        {
           
            Debug.Log("Wrong Answer");
            quizmanager.WrongAudio();
            RedWrong();
            quizmanager.Wrong();
            
        }
    }
    void GreenCorrectt()
    {

        var _correct = Instantiate(correctButtons, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        _correct.GetComponent<RectTransform>().localScale = new Vector3(0.39f, 0.39f, 0.4f);
        _correct.transform.parent = gameObject.transform;
        Destroy(_correct, 3);
    }
    void RedWrong()
    {

        var _Wrong = Instantiate(wrongButtons, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        _Wrong.GetComponent<RectTransform>().localScale = new Vector3(0.39f, 0.39f, 0.4f);
        _Wrong.transform.parent = gameObject.transform;
        Destroy(_Wrong, 3);
    }
}

