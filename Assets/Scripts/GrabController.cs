using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    public GameObject barrel;
    public GameObject barrelHolder;
    private bool canGrabBarrel = false;
    private bool barrelHold = false;
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
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrel") && !barrelHold)
        {
            barrel = other.gameObject;
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
