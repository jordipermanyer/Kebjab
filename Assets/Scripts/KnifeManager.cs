using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnifeManager : MonoBehaviour
{

    public static KnifeManager instance;
    private AudioSource sound;
    private AudioClip slice;
    public GameObject kebabTallat;

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
        sound = SoundManager.instance.GetComponent<AudioSource>();
        slice = SoundManager.instance.slice;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("kebab"))
        {
            Debug.Log("kebab chopped");
            sound.PlayOneShot(slice);
            Destroy(col.gameObject);
            Instantiate(kebabTallat, col.gameObject.transform.position, col.gameObject.transform.rotation);

            //Aplica vibració als Controladors
            //VibrationScript.instance.StartVibration();

            ScoreManager.instance.AddScore();
        }
    }
}
