using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//child of Fish class
public class NormalFish : MonoBehaviour
{
    //movement of fish
    public override void Move()
    {
        //Fish will move left or right based on its direction
        //Time.deltaTime makes movement smooth in an animation
        //the multiplication is: base direction * how fast the fish * 1 or -1 direction * uniform and smooth speed 
        transform.position += Vector3.right * swimSpeed * direction * Time.deltaTime;

        //Check the current distance that the fish has swam and this will help determine if the fish is out of bounds
        float distanceFromStart = transform.position.x - startPoint.x;

        //Check distance point: If the fish swam too far right(1), flip to go left(-1)
        if (distanceFromStart > swimDistance)
        {
            direction = -1; //left
            FlipFish(); //flips the fish
        }

        //Check distance point: If the fish swam too far left (-1), flip to go right (1)
        if (distanceFromStart < -swimDistance)
        {
            direction = 1; //right
            FlipFish(); //flips fish
        }
    }

}
