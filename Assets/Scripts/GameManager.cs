using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spider_pref, spyder2, spy3;
    public bool gameActive = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSpider", 1.0f, 2.0f);
    }

    // Update is called once per frame
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
        gameActive = false;
        Debug.Log("Lose Game");
    }
}
