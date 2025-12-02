using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FishController : MonoBehaviour
{
    //Variable1: the pink circle object
    public GameObject pinkBaitPrefab;

    //Variable2: pink bait ball should be in the point of the fishing pole
    public Transform spawnPoint;

    //Variable3: the speed of how fast the rod goes up/down
    //before I used to have a float for the speed of the ball only but 
    //but now I am trying to control the rod instead of the ball
    public float speedOfRod = 3f;

    //Variable4: the distance of how far down the rod goes
    public float maxDepth = 8f; 



    //to move the bait ball and be able to destroy it later
    //currentBait keeps track of the curr bait ball that is in the water
    private GameObject currentBait;

    //isFishing is a boolean because it tracks whether the user is currently 
    //fishing, this keeps the user from spawning multiple baits at a time. 
    private bool isFishing = false; 




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


        //Now to spawn the bait, the location of the spawn and prefab need to be checked
        if (pinkBaitPrefab != null && spawnPoint != null)
        {
            //Needs to create a copy of the bait that'll show
            // on the screen using Instantiate
            currentBait = Instantiate(pinkBaitPrefab, spawnPoint.position, spawnPoint.rotation);

            //get the physics Rigidbody2D from the bait that gets stored in rb
            //to control the gravity aspect of what was just spawned
            Rigidbody2D rb = currentBait.GetComponent<Rigidbody2D>();

            //turn off gravity so it doesn't move on its own
            rb.gravityScale = 0;

            //Velocity should be zero to stop any movement
            //BUG: velocity was capitalized when it shouldn't have been
            rb.velocity = Vector2.zero;
        }
    

    

        //to move the bait down slowly, we have to track how far its moved down
        float distanceTraveled = 0;

        //while distanceTraveled is less than maxDepth AND if the currentBait still exits
        //then keep moving down until maxDepth is met or the ball is destroyed (caught a fish)
        while (distanceTraveled < maxDepth && currentBait != null)
        {
            //Vector3.down is downward direction (0,-1,0)
            //rodSpeed controls how fast its going down
            //Time.deltaTime make it a smooth transition (not choppy and same speed on all screens)
            currentBait.transform.position += Vector3.down * speedOfRod * Time.deltaTime;

            //add to distanceTraveled tracker
            distanceTraveled += speedOfRod * Time.deltaTime;

            //yield return null allows there to be a "pause", waits one frame before continuting again
            yield return null;
        }

    
        // onces it reaches the bottom wait a little bit (0.3 seconds) before coming back up
        yield return new WaitForSeconds(0.3f);




        // //Move the bait back up only if the bait still exists 
        // if (currentBait != null)
        // {
        //     //move up until the tip of the rod has been met again so
        //     //while the bait is not null AND the bait's y position (vertical)
        //     //  is less than the spawnPoint's y position
        //     while (currentBait != null && currentBait.transform.position.y < spawnPoint.position.y)
        //     {
        //         //move bait up using Vector3.up (upward direction) (0,1,0)
        //         currentBait.transform.position += Vector3.up * speedOfRod * Time.deltaTime;

        //         //wait one frame then continue
        //         yield return null;
        //     }
        
        // }
        // //onces it reaches the bottom wait 0.2 seconds
        // yield return new WaitForSeconds(0.2f);






        //check if the bait still exists 
        //it could have been destroyed when it caught a fish (if so, then it does nothing)
        // but if it does still exist
        //destroy it
        if (currentBait != null)
        {
            Destroy(currentBait);
        }

        //set isFishing back to false so user can play again
        isFishing = false;

        //BUG: the bracket brace that closes the fishingcycle function was not there 
        //so I had to fix it. 
    }

}
