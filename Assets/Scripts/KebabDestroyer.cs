using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KebabDestroyer : MonoBehaviour
{
    AudioClip kebabSplash;
    private AudioSource sound;
    public GameObject Manchakebab;
    private GameObject manchakebabOld;
    

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
            manchakebabOld = Instantiate(Manchakebab, col.gameObject.transform.position, Quaternion.Euler(0f, 0f, 0f));
            Destroy(col.gameObject);
            Destroy(manchakebabOld, 5f);
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
