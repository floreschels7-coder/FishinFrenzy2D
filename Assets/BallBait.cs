using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBait : MonoBehaviour
{

    //5 secs before the ball disappears.
    public float timeOfBall = 5;
    void Start()
    {
        //this should destroy the circle/ball once it reaches 5 secs.
        Destroy(gameObject, timeOfBall);
            }

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //if this 'otherObject' falls into the "Fish" category then...
        if (otherObject.CompareTag("Fish"))
            {
                //destory this 'otherObject'
                Destroy(otherObject.gameObject);

                //That is essentially earning 1 point that will get added to the total score
                totalScore.instance.AddToScore(1);

                Destroy(gameObject);
            }
    }
}
