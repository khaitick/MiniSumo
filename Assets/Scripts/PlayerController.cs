using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float powerupStrength = 10f;

    public float powerupCooldown = 5f;

    public GameObject powerupIndicator;
    private Transform focalPoint;
    private Rigidbody rb;

    private bool hasPowerup;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point").GetComponent<Transform>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(focalPoint.forward * speed * (verticalInput * 2f));
        rb.AddForce(focalPoint.right * speed * (horizontalInput * 1.25f));

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            StartCoroutine(Powerup());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBoss")) && hasPowerup)
        {
            Rigidbody rbEnemy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 enemyDirection = collision.gameObject.transform.position - transform.position;

            rbEnemy.AddForce(enemyDirection * powerupStrength, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("EnemyBoss"))
        {
            rb.AddForce(-focalPoint.forward * (powerupStrength ));            
        }
    }

    IEnumerator Powerup()
    {
        hasPowerup = true;
        powerupIndicator.gameObject.SetActive(true);
        yield return new WaitForSeconds(powerupCooldown);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
