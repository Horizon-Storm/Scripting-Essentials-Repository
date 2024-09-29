using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    //Public Variables
    public float moveSpeed = 5f;
    
    //Private Variables
    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 movementVector = Vector3.zero;
    
    // Start is called before the first frame update
    private void Start()
    {
        //Cache references to components
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        KeepCharacterOnXAxis();
    }

    private void MoveCharacter()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector *= (moveSpeed * Time.deltaTime);
        controller.Move(movementVector);
    }

    private void KeepCharacterOnXAxis()
    {
        //Use cached transform reference and optimized vector creation
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
