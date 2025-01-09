using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int score, lives;
    //a collection of objects to spawn
    //public GameObject[] targets;

    public List<GameObject> targets;
    public Vector2 spawnRate;

    public bool isGameOver;
    public UnityEvent gameOver;

    [Header("User Interface Elements")]
    public GameObject gameOverScreen;
    public GameObject HUD, newHighscoreText;
    public TMP_Text scoreText, livesText, scoreTextGameOver, highscoreText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
        Debug.Log(targets.Count);
    }

    public void updateUI(int scoreChange, int livesChanged)
    {
        score += scoreChange;
        lives += livesChanged;
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        if (lives <= 0)
        {
            gameOverState();
        }
    }

    void gameOverState()
    {
        gameOver.Invoke();
        scoreTextGameOver.text = "SCORE : " + score;
        highscoreText.text = "HIGHSCORE : " + PlayerPrefs.GetInt("Highscore");
        isGameOver = true;
        HUD.SetActive(false);
        gameOverScreen.SetActive(true);

        if(PlayerPrefs.GetInt("Highscore") < score)
        {
            highscoreText.text = "OLD SCORE : " + PlayerPrefs.GetInt("Highscore");
            PlayerPrefs.SetInt("Highscore", score);
            newHighscoreText.SetActive(true);

            scoreTextGameOver.text = "HIGHSCORE : " + score;
           
        }
    }
    public void startGame(float spawnR)
    {
        StartCoroutine(spawnObjects());
        spawnRate = new Vector2(spawnR, spawnR+1);
    }


    public void restartLevel()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator spawnObjects()
    {
        while(!isGameOver)
        {
            //pick a random object to spawn
            int spawnIndex = Random.Range(0, targets.Count);
            //spawn an object
            Instantiate(targets[spawnIndex]);

            float randomWaitTime = Random.Range(spawnRate.x, spawnRate.y);
            //wait for a few seconds
            yield return new WaitForSeconds(randomWaitTime);
        }
    }
}
