using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleIDMatchBehavior : MonoBehaviour
{
    public ID id;

    public UnityEvent matchEvent, noMatchEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var otherID = other.GetComponent<SimpleIdBehavior>();

        if (otherID.id == id)
        {
            matchEvent.Invoke();
            Debug.Log("Matched ID: " + id);
        }
        else
        {
            noMatchEvent.Invoke();
            Debug.Log("No Match: " + id);
        }
    }

    
}
