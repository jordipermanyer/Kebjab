using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public int currentScore;
    public static ScoreManager instance;
    public int lifes;
    private Image life1;
    private Image life2;
    private Image life3;
    private Sprite kebabLost;
    private Sprite kebaboriginal;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        
        life1 = UiManager.instance.life1;
        life2 = UiManager.instance.life2;
        life3 = UiManager.instance.life3;
        kebabLost = UiManager.instance.kebabLost;
        kebaboriginal = UiManager.instance.kebabOriginal;
        lifes = 3;
        currentScore = 0;
    }

    public void AddScore()
    {
        currentScore = currentScore + 1;
        if(currentScore > PlayerPrefs.GetInt("HighscoreNum", 0))
            {
            PlayerPrefs.SetInt("HighscoreNum", currentScore);
            }
    }

    public void looseLife()
    {
        lifes = lifes - 1;
        if(lifes == 2)
        {
            life1.sprite = kebabLost;
        }
        if (lifes == 1)
        {
            life2.sprite = kebabLost;
        }
        if (lifes == 0)
        {
            life3.sprite = kebabLost;
            GameManager.instance.GameLost();
        }
    }

    public void restartlifes()
    {
        lifes = 3;
        life1.sprite = kebaboriginal;
        life2.sprite = kebaboriginal;
        life3.sprite = kebaboriginal;

    }

    public void resetHisghScore()
    {
        PlayerPrefs.DeleteKey("HighscoreNum");
    }
}
