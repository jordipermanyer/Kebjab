using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kebabSpawnManager : MonoBehaviour
{
    public GameObject[] Spawnpoints;
    public GameObject kebabprefab;


    public float timelapse;
    public static kebabSpawnManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
    }

    public void StartSpawn()
    {
        Debug.Log("new spawn");
        StartCoroutine("beginSpawn");
    }

    IEnumerator beginSpawn()
    {
        yield return new WaitForSeconds(timelapse);
        timelapse -= Time.deltaTime;
        if (timelapse <= 0.0f)
        {
            Debug.Log("new kebab spawn");
            int Spawnlocation = Random.Range(0, 3);
            int numrandom = Random.Range(0, 100);
            Instantiate(kebabprefab, Spawnpoints[Spawnlocation].transform.position, Quaternion.Euler(numrandom, numrandom, numrandom));

            timelapse = 1.2f;
        }

    }

}
