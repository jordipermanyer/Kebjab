using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KebabDestroyer : MonoBehaviour
{
    AudioClip kebabSplash;
    private AudioSource sound;
    

    void Start()
    {
        sound = SoundManager.instance.GetComponent<AudioSource>();
        kebabSplash = SoundManager.instance.kebabSplash;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("kebab"))
        {
            Destroy(col.gameObject);
            sound.PlayOneShot(kebabSplash);
            Debug.Log("Object Destroyed");
            ScoreManager.instance.looseLife();
            

        }
        if (col.gameObject.CompareTag("kebabPartido"))
        {
            Destroy(col.gameObject);
        }

    }
}
