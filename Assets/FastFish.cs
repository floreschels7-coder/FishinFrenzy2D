using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of parent class Fish
public class FastFish : MonoBehaviour
{

    //faster swim than normal fish
    public float fasterSpeed = 1.5f;
    
    public override void Move()
    {
        //if swim speed is 2 and the faster speed is 1.5 then 
        //multiply them both to set the speed to 3
        transform.position += Vector3.right * (swimSpeed*fasterSpeed)*direction*Time.deltaTime;

        //Check the current distance that the fish has swam and this will help determine if the fish is out of bounds
        float distanceFromStart = transform.position.x - startPoint.x;

        //Check distance point: If the fish swam too far right(1), flip to go left(-1)
        if (distanceFromStart > swimDistance)
        {
            FlipFish(); //flips the fish
        }

        //Check distance point: If the fish swam too far left (-1), flip to go right (1)
        if (distanceFromStart < -swimDistance)
        {
            FlipFish(); //flips fish
        }
    }
}
