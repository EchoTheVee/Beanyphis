using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            door.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(collision.gameObject); //mmmm
        }
    }
}
