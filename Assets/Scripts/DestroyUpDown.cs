using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUpDown : MonoBehaviour
{
    private float aboveScene = 5.0f;
    private float belowScene = -1.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > aboveScene)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < belowScene)
        {
            Destroy(gameObject);
        }
    }
}
