using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KebabDestroyer : MonoBehaviour
{
    AudioClip kebabSplash;
    private AudioSource sound;
    public GameObject kebabTallat;

    void Start()
    {
        sound = SoundManager.instance.GetComponent<AudioSource>();
        kebabSplash = SoundManager.instance.kebabSplash;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("kebab") || (col.gameObject.CompareTag("kebabPartido")))
        {
            Destroy(col.gameObject);
            sound.PlayOneShot(kebabSplash);
            //ScoreManager.instance.AddScore();
            Debug.Log("Object Destroyed");
        }
    }
}
