using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Quiz Manager bizim oyunumuzun bütün işlemlerini yapan alan soruları çekme oyuna gönderme falan filan...
/// </summary>
public class QuizManager : MonoBehaviour
{
    //Bu liste Sorularımızın yapısından oluşan bir liste soruları içinde barındırıyor
    public List<SpawnManagerScriptableObject> qnA;

    //options listesi bizim butonların bulundugu liste
    public GameObject[] options;
    public int currentQuestion = 0;

    //Bu paneller oyun içinde açıp kapayarak oyun sonunun oluşmasını oluşturan kısım
    public GameObject quizPanel;
    public GameObject goPanel;
    public GameObject audioPanel;
    public GameObject textPanel;
    public GameObject imagePanel;
    public GameObject lSelectPanel;

    public LevelManager lLManager;

    public GameObject levelScript;
    public GameObject lBust;
    //Bu alan bizim soruların gelen parçalarını ekranda nereye yansıtcagmızı gösteren parçaların bulundugu yer
    public Image resim;
    public GameObject _audio;
    public Text questionTxt;
    public Text scoreText;
    public Text imageText;

    public int level = 0;

    //bunlarda bizim game sonu ekranında gösterilen sayılar
    

    public AudioClip wrongClip;
    public AudioClip correctClip;
    

    int totalQuestions = 0;
    public int score;

    void Start()
    {
        lSelectPanel.SetActive(true);
        //totalQuestions = qnA[level].qnA.Count;
        //goPanel.SetActive(false);
        //quizPanel.SetActive(true);
        //currentQuestion = 0;
        //GenerateQuestion();
    }
    //Bu kod game ekranı sonunda retry e tıkladıgımızda scene ekranı güncelliyor ve sildigimiz bütün soruları geri getirerek sanki unity de oyunu kapayıp açmışız gibi yapıyo resetliyo yani
    public void Retry()
    {

        score = 0;
        totalQuestions = qnA[level].qnA.Count;
        goPanel.SetActive(false);
        quizPanel.SetActive(true);
        currentQuestion = 0;
        GenerateQuestion();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    //GameOver yani bizim soruları cevapladıktan sonra cıkan ekranımız
    public void GameOver()
    {
        
        quizPanel.SetActive(false);
        goPanel.SetActive(true);
        scoreText.text = score + "/" + totalQuestions;
        if (score == totalQuestions)
        {
            var particleS = lBust.GetComponent<ParticleScript>();
            particleS.PlayParticle();
        }
    }
    //Dogru cevap 
    public void Correct()
    {
        
        ButtonsDefuse();
        
        //StartCoroutine(AudioPause());
        StartCoroutine(Waiting());

        //when you answer right
        score++;
        currentQuestion++;
        //qnA[level].qnA.RemoveAt(currentQuestion);
        
    }
    //yanlış cevap
    public void Wrong()
    {
        ButtonsDefuse();
        //var a = _audio.GetComponent<AudioSource>();
        //a.Pause();
        //WrongAudio();
        currentQuestion++;
        StartCoroutine(Waiting());
        //var b = (qnA[level].qnA[currentQuestion].CorrectAnswer)--;
        //anim=options[b].GetComponent<Animation>();
        //anim.Play();
        //when you answer wrong
        //qnA[level].qnA.RemoveAt(currentQuestion);
        //GenerateQuestion();
    }
    //Bu SetAnswer bizim butonlara soruların cevaplarının atandıgı yer
    void SetAnswer()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = qnA[level].qnA[currentQuestion].Answer[i];
            if (qnA[level].qnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                
                //correctButtons.transform.position = options[i].transform.position;
                
            }
        }
    }
    void ButtonsDefuse()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = false;
        }
    }
    void ButtonActivate()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Button>().interactable = true;
        }
    }
    //soruların yeniden oluşturuldugu yer
    void GenerateQuestion()
    {
        ButtonActivate();
        if (currentQuestion != qnA[level].qnA.Count)
        {
            if (qnA[level].qnA[currentQuestion].audio != null)
            {
                //sorunun audio kısmını burası atıyor 
                if (qnA[level].qnA[currentQuestion].image != null)
                { isImageed(currentQuestion); }
                AudioPlay(currentQuestion);
            }
            else if (qnA[level].qnA[currentQuestion].image != null)
            {
                isImageed(currentQuestion);
            }
            else
            {
                TextQuestions();

            }
            //burası text in koyacagı yere text i atıyor.
            questionTxt.text = qnA[level].qnA[currentQuestion].Question;
            //Burası resim i atıyor

            SetAnswer();
            
            //currentQuestion++;
        }
        //sorular biterse buraya gidiyor gamesonu ekranı
        else
        {
            Debug.Log("Out Of Question");
            GameOver();
        }

    }
    public void TextQuestions()
    {
        
        imagePanel.SetActive(false);
        textPanel.SetActive(true);
        audioPanel.SetActive(false);

    }
    public void AudioPlay(int _currentQuestion)
    {
        textPanel.SetActive(false);
        imagePanel.SetActive(true);
        audioPanel.SetActive(true);
        _audio.GetComponent<AudioSource>().clip = qnA[level].qnA[currentQuestion].audio;
        var a = _audio.GetComponent<AudioSource>();
        a.Play();
    }
    public void isImageed(int _currentQuestion)
    {
        audioPanel.SetActive(false);
        imagePanel.SetActive(true);
        textPanel.SetActive(false);
        imageText.text = qnA[level].qnA[currentQuestion].Question;
        resim.sprite = qnA[level].qnA[currentQuestion].image;
    }
    public void next()
    {
        level++;
        score = 0;
        _Next();

    }
    public void levelSelect(int i)
    {
        lSelectPanel.SetActive(false);
        level = i;
        _Next();
    }
    void _Next()
    {
        levelScript.GetComponent<LevelScript>().Pass();
        totalQuestions = qnA[level].qnA.Count;
        goPanel.SetActive(false);
        quizPanel.SetActive(true);
        currentQuestion = 0;
        GenerateQuestion();
    }
    private IEnumerator Waiting()
    {

        yield return new WaitForSeconds(3);
        

        GenerateQuestion();
    }
    //private IEnumerator AudioPause()
    //{
    //    yield return new WaitForSeconds(3);
    //    //var a = _audio.GetComponent<AudioSource>();
    //    //a.Pause();
    //}
    private void Update()
    {
        if (qnA.Count == level)
        {
            goPanel.SetActive(false);
            quizPanel.SetActive(false);
            lSelectPanel.SetActive(true);
            //levelScript.GetComponent<LevelScript>().Pass();
            lLManager.GetComponent<LevelManager>().Start();
        }
    }
   public void CorrectAudio()
    {

        _audio.GetComponent<AudioSource>().clip = correctClip;
        var a = _audio.GetComponent<AudioSource>();
        a.Play();
        
    }
    public void WrongAudio()
    {

        _audio.GetComponent<AudioSource>().clip = wrongClip;
        var a = _audio.GetComponent<AudioSource>();
        a.Play();

    }

}
