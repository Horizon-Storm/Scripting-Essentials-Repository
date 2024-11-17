using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem), typeof(Collider2D))]
public class TriggerParticleEffect : MonoBehaviour
{
    private ParticleSystem _particleSystem; //Reference to the Particle System

    //public int particleAmmount = 10; //Exposed Variable for Particle Ammount
    
    public int firstparticleAmmount = 10; //Exposed Variable for first Particle Ammount
    public int secondparticleAmmount = 20; //Exposed Variable for second Particle Ammount
    public int thirdparticleAmmount = 30; //Exposed Variable for third Particle Ammount
    public float delayBetweenEmissions = 0.5f; //Delay time between emissions
    
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterController>()) ;//Check if player triggered event
        {
            StartCoroutine(EmitParticlesCoroutine());
        }
        
        //if (other.gameObject.GetComponent<CharacterController>()); //Check if player triggers the event
        //{
          //  _particleSystem.Emit(particleAmmount); //Emit specified amount of particles
      //  }
        //if(other.gameObject.tag == "enemy)
        //{}
    }

    private IEnumerator EmitParticlesCoroutine()
    {
        //first emission
        _particleSystem.Emit(firstparticleAmmount); //Emit based on exposed variable
        yield return new WaitForSeconds(delayBetweenEmissions); //Wait specified time
        
        //second emission
        _particleSystem.Emit(secondparticleAmmount); //Emit based on exposed variable
        yield return new WaitForSeconds(delayBetweenEmissions); //Wait specified time
        
        //third emission
        _particleSystem.Emit(thirdparticleAmmount); //Emit based on exposed variable
        yield return new WaitForSeconds(delayBetweenEmissions); //Wait specified time
    }
}
