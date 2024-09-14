using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ColorChange : MonoBehaviour
{

    //public Color newColor = UnityEngine.Random.ColorHSV(0f, 1f, 1f, 0.5f, 1f, 1f);
    public Color newColor;
   
    void OnCollisionEnter(Collision collision)
    {
        Color newColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        GetComponent<Renderer>().material.color = newColor;
    }
}
