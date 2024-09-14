using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkOnCollision : MonoBehaviour
{
    public float shrinkFactor = 0.9f;

    private void OnCollisionEnter(Collision other)
    {
        //Scale the object down when it collides with another object
        transform.localScale *= shrinkFactor;
    }
   
}
