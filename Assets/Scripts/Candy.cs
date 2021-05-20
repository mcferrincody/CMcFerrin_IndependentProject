using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Rigidbody candyRB;
    // Start is called before the first frame update
    void Start()
    {
        candyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        Destroy(other.gameObject);
    }
}
