using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogramPlant : MonoBehaviour
{
    public float speed = 3.0f;
    private PlayerController playerCtrl;
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerCtrl.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}