using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int currentScore;
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    private void Start()
    {
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

    public void resetHisghScore()
    {
        PlayerPrefs.DeleteKey("HighscoreNum");
    }
}
