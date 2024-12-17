using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwitcher : MonoBehaviour
{
    private PlayerController pc;
    private GrabController gc;
    // Start is called before the first frame update
    void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        gc = GameObject.Find("BarrelGrabHitbox").GetComponent<GrabController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gc.free1.SetActive(false);
            gc.free2.SetActive(false);
            gc.push1.SetActive(true);
            gc.push2.SetActive(true);
        }
    }
}
