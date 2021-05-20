using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spider_pref;
    public bool gameActive = true;
    GameEnding m_GameEnding;
    GameEnding m_IsPlayerAtExit;
    // Start is called before the first frame update
    void Start()
    {
        m_GameEnding = GameObject.Find("GameEnding").GetComponent<GameEnding>();
        InvokeRepeating("SpawnSpider", 1.5f, 2.0f);
    }

    // Update is called once per frame
    void SpawnSpider()
    {
        while (gameActive)
        {
            Instantiate(spider_pref);
        }
    }
    public void LoseGame()
    {
        m_GameEnding.CaughtPlayer();
        m_IsPlayerAtExit.CaughtPlayer();
        gameActive = false;
        Debug.Log("Lose Game");
    }
}
