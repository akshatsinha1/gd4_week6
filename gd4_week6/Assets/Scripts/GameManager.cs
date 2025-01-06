using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int score, lives;
    //a collection of objects to spawn
    //public GameObject[] targets;

    public List<GameObject> targets;

    public bool isGameOver;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnObjects());
        Debug.Log(targets.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnObjects()
    {
        while(!isGameOver)
        {
            //pick a random object to spawn
            int spawnIndex = Random.Range(0, targets.Count);
            //spawn an object
            Instantiate(targets[spawnIndex]);

            float randomWaitTime = Random.Range(0.5f, 2);
            //wait for a few seconds
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
}
