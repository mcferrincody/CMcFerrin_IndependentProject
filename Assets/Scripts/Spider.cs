using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    void Update()
    {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}