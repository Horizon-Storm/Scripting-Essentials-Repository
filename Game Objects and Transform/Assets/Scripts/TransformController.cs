using UnityEngine;


public class TransformController : MonoBehaviour
{
    //Public Rotation Variables
    public float rotateX = 30;
    public float rotateY = 30;
    public float rotateZ = 30;
    
    //Public Movement Variables
    public float distanceX = 5;
    
    //Public Speed Variable
    public float moveSpeed = 1;
    private void Update()
    {
        //Move the target GameObject
        //var x = Mathf.PingPong(Time.time, 3);
        //var p = new Vector3(0, x, 0);
        //transform.position = p;
        
        //Move Side to side
        var moveX = Mathf.PingPong(Time.time * moveSpeed, distanceX); 
        
        transform.position = new Vector3(moveX, 0, 0);




        //Rotate the target Game Object
        transform.Rotate(new Vector3(rotateX, rotateY, rotateZ) * Time.deltaTime);
    }
}