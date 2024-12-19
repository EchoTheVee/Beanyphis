
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody crateRb;
    public float moveSpeed;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        crateRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        crateRb.AddRelativeForce(Vector2.right * moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log($"You've been struck by a smooth {other.gameObject.name}");
            transform.Rotate(Vector3.up * 180);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            //other.gameObject.SetActive(false);
            playerController.hp = playerController.hp - 1;
        }
    }
}
