using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject _targetA;
    public GameObject _targetB;
    public GameObject _currentTarget; // = _targetA;
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceToA = Vector3.Distance(transform.position, _targetA.transform.position);
        float distanceToB = Vector3.Distance(transform.position, _targetB.transform.position);

        if (distanceToA == 0f)
        {
            _currentTarget = _targetB;
        }

        if (distanceToB == 0f)
        {
            _currentTarget = _targetA;
        }
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.transform.position, _speed * Time.deltaTime);
    }
}
