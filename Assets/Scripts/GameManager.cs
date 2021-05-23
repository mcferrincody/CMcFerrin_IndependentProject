using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Candy;
    public GameObject spider_pref, spyder2, spy3;
    private bool _gameActive = false;
    public bool gameActive { get { return _gameActive; } }
    public Button restartButton;
    public GameObject titleScreen;

    public TextMeshProUGUI scoreText;
    private int score = 0;
    public void StartGame()
    {
        Debug.Log("Start game");
        _gameActive = true;
        InvokeRepeating("SpawnSpider", 1.0f, 2.0f);
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    void SpawnSpider()
    {
        if (gameActive)
        {
            Instantiate(spider_pref);
            Instantiate(spyder2);
            Instantiate(spy3);
        }
    }

    public void LoseGame()
    {
        _gameActive = false;
        restartButton.gameObject.SetActive(true);
        Debug.Log("Game Over");
    }
    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
