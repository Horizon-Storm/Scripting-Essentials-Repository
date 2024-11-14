using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem; //Reference to the Particle System

    public int particleAmmount = 10; //Exposed Variable for Particle Ammount
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterController>()) ;//Check if player triggers the event
        {
            _particleSystem.Emit(particleAmmount); //Emit specified amount of particles
        }
        //if(other.gameObject.tag == "enemy)
        //{}
    }
}
