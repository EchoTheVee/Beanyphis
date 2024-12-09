using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody playerRb;
    public float movementSpeed;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector2.right * movementSpeed * horizontalInput);

        if (Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector2.up * jumpForce);
        }
    }
}
