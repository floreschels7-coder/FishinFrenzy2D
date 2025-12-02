using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FishController : MonoBehaviour
{

     //5 secs before the ball disappears.
    public float timeOfBall = 5;

    //Variable1: the pink circle object
    public GameObject pinkBait;

    //Variable2: pink bait ball should be in the point of the fishing pole
    public Transform spawnPoint;

    //Variable3: the speed of how fast the rod goes up/down
    //before I used to have a float for the speed of the ball only but 
    //but now I am trying to control the rod instead of the ball
    public float speedOfRod = 3f;

    //Variable4: the distance of how far down the rod goes
    public float maxDepth = 8f; 

    //isFishing is a boolean because it tracks whether the user is currently 
    //fishing, this keeps the user from spawning multiple baits at a time. 
    public bool isFishing = false; 




    // Start is called before the first frame update
    void Start()
    {
        
    }


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
        //to control the gravity aspect of what was just spawned
        Rigidbody2D rb = pinkBait.GetComponent<Rigidbody2D>();

        //Velocity should be zero to stop any movement
        //BUG: velocity was capitalized when it shouldn't have been
        rb.velocity = new Vector2(0, -speedOfRod);
        

        while (isFishing)
        {
            yield return null; 
        }
        rb.velocity = new Vector2(0, speedOfRod);
    

    

        // //to move the bait down slowly, we have to track how far its moved down
        // float distanceTraveled = 0;

        //while distanceTraveled is less than maxDepth AND if the currentBait still exits
        //then keep moving down until maxDepth is met or the ball is destroyed (caught a fish)
        // while (distanceTraveled < maxDepth && currentBait != null)
        // {
        //     //Vector3.down is downward direction (0,-1,0)
        //     //rodSpeed controls how fast its going down
        //     //Time.deltaTime make it a smooth transition (not choppy and same speed on all screens)
        //     currentBait.transform.position += Vector3.down * speedOfRod * Time.deltaTime;

        //     //add to distanceTraveled tracker
        //     distanceTraveled += speedOfRod * Time.deltaTime;

        //     //yield return null allows there to be a "pause", waits one frame before continuting again
        //     yield return null;
        // }

    
        // // onces it reaches the bottom wait a little bit (0.3 seconds) before coming back up
        // yield return new WaitForSeconds(0.3f);

        // //set isFishing back to false so user can play again
        // isFishing = false;

    }

}
