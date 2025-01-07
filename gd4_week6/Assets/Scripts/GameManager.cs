using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score, lives;
    //a collection of objects to spawn
    //public GameObject[] targets;

    public List<GameObject> targets;

    public bool isGameOver;

    public TMP_Text scoreText, livesText;

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

    public void updateUI(int scoreChange, int livesChanged)
    {
        score += scoreChange;
        lives += livesChanged;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            isGameOver = true;
        }
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
