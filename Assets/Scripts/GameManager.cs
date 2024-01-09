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
    private AudioSource sound;
    private bool gameStarted = false;
    public GameObject TOPkebabdestroyer;

    
    GameObject GameOverCanvas;
    GameObject MainScoreCanvas;
    GameObject HighScoreCanvas;
    GameObject StartMenuCanvas;
    GameObject MainGameCanvas;
    GameObject TimeOuTxt;
    TextMeshProUGUI ScorePoints;
    TextMeshProUGUI HighScorePoints;


    AudioClip mainTheme;
    AudioClip pitidoFinal;
    AudioClip empiezaElJuego;
    AudioClip MenuSong;

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
        pitidoFinal = SoundManager.instance.pitidoFinal;
        MainScoreCanvas = UiManager.instance.ScoretextCanvas;
        HighScoreCanvas = UiManager.instance.HighScoretextCanvas;
        TimeOuTxt = UiManager.instance.TimeOuttext;
        ScorePoints = UiManager.instance.scorepoints;
        HighScorePoints = UiManager.instance.HighScorepoints;
        sound.PlayOneShot(MenuSong);

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
        TOPkebabdestroyer.SetActive(false);
        ScoreManager.instance.resetHisghScore();
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
        EndGame();
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

    private IEnumerator WaitForEndGameCanvas()
    {
        yield return new WaitForSeconds(3f);
        GameOverCanvas.SetActive(true);

    }



    public void SelectInstructions()
    {
        Debug.Log("instructions selected");
    }

    private void EndGame()
    {
        TOPkebabdestroyer.SetActive(true);
        gameStarted = false;
        StartCoroutine(ShowHighScore());
        sound.Stop();
        sound.PlayOneShot(pitidoFinal);
        StartCoroutine(WaitForEndGameCanvas());
        
        
    }

    public void ExitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
