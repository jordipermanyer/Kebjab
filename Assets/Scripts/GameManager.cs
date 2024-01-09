using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;

    public Image Barfill;
    public float gameTime;
    private float initialGameTime;
    private AudioSource sound;
    private bool gameStarted = false;
    private bool gameIsLost = false;
    public GameObject TOPkebabdestroyer;

    
    GameObject GameOverCanvas;
    GameObject MainScoreCanvas;
    GameObject HighScoreCanvas;
    GameObject StartMenuCanvas;
    GameObject MainGameCanvas;
    GameObject Instructionscanvas;
    GameObject InstructionsBtn;
    GameObject InstructionsArrow;
    GameObject LifesCanvas;
    GameObject TimeOuTxt;
    GameObject Youloosetext;
    TextMeshProUGUI ScorePoints;
    TextMeshProUGUI HighScorePoints;


    AudioClip mainTheme;
    AudioClip pitidoFinal;
    AudioClip empiezaElJuego;
    AudioClip MenuSong;
    AudioClip GameLostAudio;

    public static GameManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.instance.GetComponent<AudioSource>();
        GameOverCanvas = UiManager.instance.GameOverCanvas;
        StartMenuCanvas = UiManager.instance.StartMenuCanvas;
        MainGameCanvas = UiManager.instance.MainGameCanvas;
        mainTheme = SoundManager.instance.Maintheme;
        MenuSong = SoundManager.instance.MenuSong;
        empiezaElJuego = SoundManager.instance.empiezaEljuego;
        GameLostAudio = SoundManager.instance.GameLost;
        pitidoFinal = SoundManager.instance.pitidoFinal;
        MainScoreCanvas = UiManager.instance.ScoretextCanvas;
        HighScoreCanvas = UiManager.instance.HighScoretextCanvas;
        Instructionscanvas = UiManager.instance.InstructionsImage;
        InstructionsArrow = UiManager.instance.InstructionsArrow;
        InstructionsBtn = UiManager.instance.InstructionsBtn;
        LifesCanvas = UiManager.instance.LifesCanvas;
        TimeOuTxt = UiManager.instance.TimeOuttext;
        Youloosetext = UiManager.instance.Youloosetext;
        ScorePoints = UiManager.instance.scorepoints;
        HighScorePoints = UiManager.instance.HighScorepoints;
        sound.PlayOneShot(MenuSong);
        initialGameTime = gameTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted)
        {
            kebabSpawnManager.instance.StartSpawn();
            ScorePoints.text = ScoreManager.instance.currentScore.ToString();
        }

    }

    public void StartGame()
    {
        gameIsLost = false;
        TOPkebabdestroyer.SetActive(false);
        ScoreManager.instance.resetHisghScore();
        Barfill.fillAmount = 1;
        gameStarted = true;
        Debug.Log("Game started");
        MainGameCanvas.SetActive(true);
        MainScoreCanvas.SetActive(true);
        StartMenuCanvas.SetActive(false);
        sound.Stop();
        sound.PlayOneShot(empiezaElJuego);
        sound.PlayOneShot(mainTheme);
        StartCoroutine(StartTimer(gameTime));
        GameOverCanvas.SetActive(false);
        TimeOuTxt.SetActive(false);
        HighScoreCanvas.SetActive(false);
        player.transform.rotation = Quaternion.Euler(0.523f, 445.598f, 0.055f);
        cam.transform.position = new Vector3(cam.transform.position.x+2, cam.transform.position.y, cam.transform.position.z);



    }

    public void reloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void restartMatch()
    {
        gameIsLost = false;
        gameTime = initialGameTime;
        LifesCanvas.SetActive(true);
        Barfill.fillAmount = 1;
        ScoreManager.instance.restartlifes();
        ScoreManager.instance.currentScore = 0;
        TOPkebabdestroyer.SetActive(false);
        MainGameCanvas.SetActive(true);
        MainScoreCanvas.SetActive(true);
        gameStarted = true;
        Debug.Log("Game started");
        sound.Stop();
        sound.PlayOneShot(empiezaElJuego);
        sound.PlayOneShot(mainTheme);
        StartCoroutine(StartTimer(gameTime));
        GameOverCanvas.SetActive(false);
        TimeOuTxt.SetActive(false);
        Youloosetext.SetActive(false);
        HighScoreCanvas.SetActive(false);
    }

    private IEnumerator StartTimer(float timerValue)
    {
        while (timerValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timerValue -= 1;

            Barfill.fillAmount = timerValue / gameTime;



        }
        if (gameIsLost == false)
        {
            EndGame();
        }
        
    }

    private IEnumerator ShowHighScore()
    {
        MainScoreCanvas.SetActive(false);
        TimeOuTxt.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        TimeOuTxt.SetActive(false);
        HighScoreCanvas.SetActive(true);
        HighScorePoints.text = PlayerPrefs.GetInt("HighscoreNum", 0).ToString();
    }
    private IEnumerator ShowHighScoreWhenGameLost()
    {
        MainScoreCanvas.SetActive(false);
        Youloosetext.SetActive(true);
        yield return new WaitForSeconds(1.2f);
        Youloosetext.SetActive(false);
        HighScoreCanvas.SetActive(true);
        HighScorePoints.text = PlayerPrefs.GetInt("HighscoreNum", 0).ToString();
    }


    private IEnumerator WaitForEndGameCanvas()
    {
        yield return new WaitForSeconds(3f);
        GameOverCanvas.SetActive(true);

    }

    private IEnumerator disableArrow()
    {
        yield return new WaitForSeconds(2.5f);
        InstructionsArrow.SetActive(false);

    }



    public void SelectInstructions()
    {
        Debug.Log("instructions selected");
        InstructionsBtn.SetActive(false);
        Instructionscanvas.SetActive(true);
        InstructionsArrow.SetActive(true);
        StartCoroutine(disableArrow());
        
    }

    private void EndGame()
    {
        Barfill.fillAmount = 0;
        LifesCanvas.SetActive(false);
        TOPkebabdestroyer.SetActive(true);
        gameStarted = false;
        StartCoroutine(ShowHighScore());
        sound.Stop();
        sound.PlayOneShot(pitidoFinal);
        StartCoroutine(WaitForEndGameCanvas());
    }

    public void GameLost()
    {
        Barfill.fillAmount = 0;
        gameIsLost = true;
        StopAllCoroutines();
        gameTime = 0;
        LifesCanvas.SetActive(false);
        TOPkebabdestroyer.SetActive(true);
        gameStarted = false;
        StartCoroutine(ShowHighScoreWhenGameLost());
        sound.Stop();
        sound.PlayOneShot(GameLostAudio);
        StartCoroutine(WaitForEndGameCanvas());
    }



    public void ExitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
