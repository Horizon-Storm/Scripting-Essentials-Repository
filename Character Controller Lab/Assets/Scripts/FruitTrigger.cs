using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEvent triggerEvent;


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Trigger the Event, Play hit animation, and send debug message
        triggerEvent.Invoke();
        
        //Begin Destruction Coroutine
        StartCoroutine(DestroyDelay());

    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}