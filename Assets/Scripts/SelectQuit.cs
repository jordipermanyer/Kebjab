using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectQuit : MonoBehaviour
{
    private AudioSource sound;
    private AudioClip btnsound;

    // Start is called before the first frame update
    void Start()
    {
        sound = SoundManager.instance.GetComponent<AudioSource>();
        btnsound = SoundManager.instance.Btnsound;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("arma"))
        {
            sound.PlayOneShot(btnsound);
            GameManager.instance.ExitGame();
        }

    }
}
