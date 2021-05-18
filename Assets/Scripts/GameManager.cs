using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spider_pref;
    public bool gameActive = true;
    GameEnding m_GameEnding;
    // Start is called before the first frame update
    void Start()
    {
        m_GameEnding = GameObject.Find("GameEnding").GetComponent<GameEnding>();
        InvokeRepeating("SpawnSpider", 2.0f, 5.0f);
    }

    // Update is called once per frame
    void SpawnSpider()
    {
        if (gameActive)
        {
            Instantiate(spider_pref);
        }
    }
    public void LoseGame()
    {
        m_GameEnding.CaughtPlayer();
        gameActive = false;
        Debug.Log("Lose Game");
    }
}
