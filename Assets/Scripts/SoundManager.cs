using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip Maintheme;
    public AudioClip pitidoFinal;
    public AudioClip empiezaEljuego;
    public AudioClip kebabSplash;
    public AudioClip slice;
    public AudioClip Btnsound;
    public AudioClip MenuSong;
    public AudioClip GameLost;

    public static SoundManager instance;

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
