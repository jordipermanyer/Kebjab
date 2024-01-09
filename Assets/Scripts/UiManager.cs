using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject StartMenuCanvas;
    public GameObject MainGameCanvas;
    public GameObject GameOverCanvas;

    public GameObject ScoretextCanvas;
    public GameObject HighScoretextCanvas;
    public GameObject TimeOuttext;
    public TextMeshProUGUI scorepoints;
    public TextMeshProUGUI HighScorepoints;

    public static UiManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

}
