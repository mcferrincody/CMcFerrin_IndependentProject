using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dogramPlant;
    private float zPosRange = 15;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomdogramPlant", 0f, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomdogramPlant()
    {
        float randZPos = Random.Range(-zPosRange, zPosRange);
        int dogramPlantIndex = Random.Range(0, dogramPlant.Length);
        Vector3 randPos = new Vector3(10, 3, randZPos);
        Instantiate(dogramPlant[dogramPlantIndex], randPos,
            dogramPlant[dogramPlantIndex].transform.rotation);
    }
}
