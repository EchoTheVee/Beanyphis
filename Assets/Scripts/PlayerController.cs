using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody playerRb;
    public float movementSpeed;
    public float jumpForce;
    private bool canJump;
    public float gravity;
    public Image heart1;
    public Image heart2;
    public Image heart3;
    public int hp = 3;
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
            playerRb.AddForce(Vector2.down * gravity, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && canJump)
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

        if (hp < 3)
        {
            heart3.gameObject.SetActive(false);
        }

        if (hp < 2)
        {
            heart2.gameObject.SetActive(false);
        }

        if (hp < 1)
        {
            heart1.gameObject.SetActive(false);
            SceneManager.LoadScene("GameOver");
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
