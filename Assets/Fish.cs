using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//parent class, only child classes can access
public abstract class Fish : MonoBehaviour
{
    //swimSpeed for how fast the fish swim
    public float swimSpeed = 2f;
    //swimDistance is how far the fish travel before turning around
    public float swimDistance = 5f;
    //scoreValue is for the amt of points the fish is worth
    public int scoreValue = 10;
    //startPoint for where the fish began
    public Vector3 startPoint;
    //1 for right direction and -1 for left direction
    public int direction = 1; 


    // Start is called before the first frame update
    void Start()
    {
        //store the point where the firsh first began
        startPoint = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        //call the Move method that each child class has 
        // their own movement method
        Move();
    }

    //declares Move() for the child classes to do their specific movement
    public abstract void Move();

    //All fish must flip so it is shared in the abstract class
    public void FlipFish()
    {
        //gets the current scale and stores it in currScale
        Vector3 currScale = transform.localScale;
        //flip x scale value of the fish sprite
        currScale.x *= -1;
        //add the updated scale back to the fish
        transform.localScale = currScale;
        //flip movement direction
        direction *= -1;  
    }
}
