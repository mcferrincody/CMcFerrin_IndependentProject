using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCaught : MonoBehaviour
{
    GameManager m_GameManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Caught by Spider");
            m_GameManager.LoseGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
