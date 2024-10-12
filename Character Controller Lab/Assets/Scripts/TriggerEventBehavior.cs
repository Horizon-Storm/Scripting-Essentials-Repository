using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEventBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    
    public UnityEvent triggerEvent;
    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        //Trigger the Event, Play hit animation, and send debug message
        triggerEvent.Invoke();
        animator.SetTrigger("Hit");
        Debug.Log("Player Interacted with Spike");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
