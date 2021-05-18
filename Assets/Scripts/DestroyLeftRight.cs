using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLeftRight : MonoBehaviour
{
    private float leftOfScene = -20.0f;
    private float rightOfScene = 22.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftOfScene)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > rightOfScene)
        {
            Destroy(gameObject);
        }
    }
}
