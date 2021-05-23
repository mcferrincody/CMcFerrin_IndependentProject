using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 20f;
    public ParticleSystem dirtSystem;
    public GameObject PowerUpInd;
    bool hasCandy = false;
    bool hasPowerUp = false;
    public float powerUpSpeed = 20.0f;

    public int pointValue = 1;
    public ParticleSystem expParticle;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (gameManager.gameActive)
        {
            m_Animator.enabled = true;
            //Getting the horizontal input movement from the user
            float horizontal = Input.GetAxis("Horizontal");
            //Getting the vertical input movement from the user
            float vertical = Input.GetAxis("Vertical");

            m_Movement.Set(horizontal, 0f, vertical);
            m_Movement.Normalize();

            bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            bool isWalking = hasHorizontalInput || hasVerticalInput;
            m_Animator.SetBool("IsWalking", isWalking);

            if (isWalking)
            {
                if (!m_AudioSource.isPlaying)
                {
                    m_AudioSource.Play();
                    dirtSystem.Play();
                }
            }
            else
            {
                m_AudioSource.Stop();
                dirtSystem.Stop();
            }

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
            m_Rotation = Quaternion.LookRotation(desiredForward);
        }
        else
        {
            m_AudioSource.Stop();
            dirtSystem.Stop();
            m_Animator.enabled = false;
        }
    }

    void OnAnimatorMove()
    {
        if (gameManager.gameActive)
        {
            //Using animations to move playerRigidbody position
            m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
            //Using animations to rotate player Rigidbody
            m_Rigidbody.MoveRotation(m_Rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power Up"))
        {
            hasPowerUp = true;
            StartCoroutine(PowerUpCountdown());
            PowerUpInd.SetActive(true);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Candy"))
        {
            Debug.Log("Candy player");
            gameManager.UpdateScore(pointValue);
            Destroy(other.gameObject);
            Instantiate(expParticle, transform.position, expParticle.transform.rotation);

        }
        if (hasPowerUp && other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collid with" + other.gameObject + "with powerup set to " + hasPowerUp);
            Rigidbody rbEnemy = other.gameObject.GetComponent<Rigidbody>();
            Destroy(other.gameObject);
        }
    }
    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        PowerUpInd.SetActive(false);
    }
}