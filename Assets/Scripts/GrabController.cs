using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public GameObject barrel;
    public Rigidbody barrelRb;
    public GameObject barrelHolder;
    private bool canGrabBarrel = false;
    private bool barrelHold = false;
    public float horizontalThrowForce;
    public float verticalThrowForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canGrabBarrel)
        {
            barrelHold = true;
        }

        if (barrelHold)
        {
            barrel.transform.position = barrelHolder.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.E) && !canGrabBarrel)
        {
            barrelHold = false;
            barrelRb.AddForce(Vector2.right * horizontalThrowForce);
            barrelRb.AddForce(Vector2.up * verticalThrowForce);
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrel") && !barrelHold)
        {
            barrel = other.gameObject;
            barrelRb = other.gameObject.GetComponent<Rigidbody>();
            canGrabBarrel = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Barrel") )
        {
            //barrel = null;
            canGrabBarrel = false;
        }
    }
}
