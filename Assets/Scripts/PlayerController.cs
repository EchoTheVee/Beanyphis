using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody playerRb;
    public float movementSpeed;
    public float jumpForce;
    private bool canJump;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * movementSpeed * horizontalInput);

        if (!canJump)
        {
            playerRb.AddForce(Vector2.down * gravity);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            playerRb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }
}
