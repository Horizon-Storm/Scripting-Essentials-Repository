using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * 500);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected with " + collision.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
