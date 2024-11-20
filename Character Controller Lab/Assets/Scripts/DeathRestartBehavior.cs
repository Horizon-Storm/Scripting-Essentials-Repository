using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class DeathRestartBehavior : MonoBehaviour
{
    public float ResetDelay = 10f;
    public UnityEvent triggerEvent;
        void OnTriggerEnter2D(Collider2D other)

        {

            if (other.CompareTag("Player")) // Check if the player triggered the collider

            {
                StartCoroutine(ResetTimerCoroutine());
                

            }

        }

        private IEnumerator ResetTimerCoroutine()
        {
            triggerEvent.Invoke();
            
            yield return new WaitForSeconds(ResetDelay); //Wait specified time
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        }
        
}
