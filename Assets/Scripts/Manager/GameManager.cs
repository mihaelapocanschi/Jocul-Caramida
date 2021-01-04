using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Core-ul jocului
public class GameManager : MonoBehaviour
{

    float slowness = 8f;

    public static bool end;
    public static bool soundOn = true;

    public int score;
    public static int highScore;
    
    public Text textGameOver,textScore,textHighScore;

    public Toggle mToggle;

    AudioSource[] audioSource;
    public AudioClip addScoreClip, gameOverClip;

    //Apelarea functiei la pornirea jocului
    void Start ()
    {
        end = false;
    }

    //Actualizarea jocului la fiecare cadru
    //Aici cauta toate sursele de sunet si le opreste/porneste
    void Update()
    {
        if (!soundOn)
        {
            foreach (AudioSource audio in audioSource)
            {
                audio.mute = true;
            }
        }
        else
        {
            foreach (AudioSource audio in audioSource)
            {
                audio.mute = false;
            }
        }
    }
 
    //Initializam componentele audio
    void Awake()
    {

        audioSource = GetComponents<AudioSource>();
      

    }

    //Verificam daca sunetul este pornit sau nu
    public void SetSFX()
    {
       
        if (soundOn)
            soundOn = false;
        else
            soundOn = true;

    }

    //Actualizarea scorului
    public void AddScore()
    {
    
            audioSource[0].clip = addScoreClip;
            audioSource[0].Play();
            score++;
            textScore.text = " " + score;

    }

    //Sfarsitul jocului
    public void EndGame()
    {
        StartCoroutine(Restart());
        end = true;
    }

    //Initializarea si verificarea celui mai mare scor
    public void SetHighScore()
    {
        if(score > highScore)
        {
            
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

    }

    //Resetarea jocului fara a distruge pierde informatii despre cel mai mare scor
    IEnumerator Restart()
    {
        audioSource[0].clip = gameOverClip;
        audioSource[0].Play();
        Time.timeScale = 1f / slowness;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        textGameOver.text = "Game Over !";
        SetHighScore();
        textHighScore.text = "High score: " + PlayerPrefs.GetInt("HighScore"); ;

        yield return new WaitForSeconds(gameOverClip.length / slowness);

        textHighScore.text = " ";
        textGameOver.text = "";
        textScore.text = "0";

        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
        Time.timeScale = 1f;
        SceneManager.LoadScene(Random.Range(0, 3));
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


    }

}
