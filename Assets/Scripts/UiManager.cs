using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject StartMenuCanvas;
    public GameObject MainGameCanvas;
    public GameObject GameOverCanvas;
    public GameObject InstructionsImage;
    public GameObject InstructionsBtn;
    public GameObject InstructionsArrow;
    public GameObject LifesCanvas;
    public Image life1;
    public Image life2;
    public Image life3;
    public Sprite kebabLost;
    public Sprite kebabOriginal;
    public GameObject ScoretextCanvas;
    public GameObject HighScoretextCanvas;
    public GameObject TimeOuttext;
    public GameObject Youloosetext;
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
