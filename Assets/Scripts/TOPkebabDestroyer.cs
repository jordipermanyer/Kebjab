using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOPkebabDestroyer : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("kebab"))
        {
            Destroy(col.gameObject);
            Debug.Log("Object Destroyed");
        }
    }
}
