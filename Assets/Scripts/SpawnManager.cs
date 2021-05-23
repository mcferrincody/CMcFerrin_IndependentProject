using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dogramPlant;
    private float zPosRange = 15;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnRandomdogramPlant", 0f, 0.5f);
    }
    void SpawnRandomdogramPlant()
    {
        if (gameManager.gameActive)
        {
            float randZPos = Random.Range(-zPosRange, zPosRange);
            int dogramPlantIndex = Random.Range(0, dogramPlant.Length);
            Vector3 randPos = new Vector3(10, 2, randZPos);
            Instantiate(dogramPlant[dogramPlantIndex], randPos,
                dogramPlant[dogramPlantIndex].transform.rotation);
        }
    }
}