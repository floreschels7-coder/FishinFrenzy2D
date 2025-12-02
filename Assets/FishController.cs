using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FishController : MonoBehaviour
{

    //Variable1: the pink circle object
    public GameObject pinkBait;

    //Variable2: pink bait ball should be in the point of the fishing pole
    public Transform spawnPoint;

    //Variable3: the speed of how fast the rod goes up/down
    public float speedOfRod = 3f;

    //isFishing is a boolean because it tracks whether the user is currently 
    //fishing, this keeps the user from spawning multiple baits at a time. 
    public bool isFishing = false; 




    // Update is called once per frame
    void Update()
    {
        //Checks two conditions:
        //if the user has pressed the spacebar and
        //if that user is not already fishing
        if (Input.GetKeyDown(KeyCode.Space) && !isFishing)
        {
            //using a coroutine lets actions spread across multiple frames in the game
            //which begins the fishing process
            //BUG: StartCoroutine was spelled wrong
            StartCoroutine(FishingCycle());
        }
    }


    //IEnumerator helps the coroutine make the rod go down and up
    IEnumerator FishingCycle()
    {
        //keeps the user from spawning multiple baits while fishing
        isFishing = true;
     


        //get the physics Rigidbody2D from the bait that gets stored in rb
        Rigidbody2D rb = pinkBait.GetComponent<Rigidbody2D>();

        //Velocity is set to go downwards
        rb.velocity = new Vector2(0, -speedOfRod);
        
        //keeps going down until it reaches the barrier 
        // and sets isFishing to false
        while (isFishing)
        {
            yield return null; 
        }
        //Now goes back up
        rb.velocity = new Vector2(0, speedOfRod);

        //the ball keeps going up until reaches the spawn point lcoation
        while (pinkBait.transform.position.y < spawnPoint.position.y)
        {
            yield return null;
        }

        //stop ball when it reaches the top
        rb.velocity = Vector2.zero;

        //Reset the ball position exactly at spawn point position
        pinkBait.transform.position = spawnPoint.position;

        //then set to false to fish again
        isFishing = false;
    

    }

}
