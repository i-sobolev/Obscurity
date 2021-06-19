using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMover : MonoBehaviour
{
    public float _speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.forward * _speed * Time.deltaTime;
    }
}
