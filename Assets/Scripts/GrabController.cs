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
    public GameObject hold1;
    public GameObject hold2;
    public GameObject free1;
    public GameObject free2;

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
            free1.gameObject.SetActive(false);
            free2.gameObject.SetActive(false);
            hold1.gameObject.SetActive(true);
            hold2.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && !canGrabBarrel)
        {
            barrelHold = false;
            StartCoroutine(BarrelThrow());
            free1.gameObject.SetActive(true);
            free2.gameObject.SetActive(true);
            hold1.gameObject.SetActive(false);
            hold2.gameObject.SetActive(false);
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

    IEnumerator BarrelThrow()
    {
        Debug.Log("YEET!");
        yield return new WaitForEndOfFrame();
        barrelRb.constraints = RigidbodyConstraints.None;
        barrelRb.AddForce(Vector2.right * horizontalThrowForce, ForceMode.Impulse);
        barrelRb.AddForce(Vector2.up * verticalThrowForce, ForceMode.Impulse);
        barrelRb = null;
    }
}
