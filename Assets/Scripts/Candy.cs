using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    private Rigidbody candyRB;
    private GameManager gameManager;

    public int pointValue;
    public ParticleSystem expParticle;

    // Start is called before the first frame update
    void Start()
    {
        candyRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Candy"))
        {
            Debug.Log("Candy picked up");
            gameManager.UpdateScore(pointValue);
            Instantiate(expParticle, other.transform.position, expParticle.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
