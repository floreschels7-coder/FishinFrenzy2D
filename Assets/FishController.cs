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
            StartCorutine(FishingCycle());
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
            
        }
    }


    void SpawnBait()
    {   
        //Do we have the prefab and location, if yes, continue
        if (pinkBaitPrefab != null && spawnPoint != null)
        {
            //Variable 'bait' will be the place where all the copies of the ball get stored. (what,where,how) parameters.
            GameObject bait = Instantiate(pinkBaitPrefab, spawnPoint.position, spawnPoint.rotation);


            //The physics of the ball that comes from Rigidbody2D essentially gets stored in rb
            Rigidbody2D rb = bait.GetComponent<Rigidbody2D>();
            
            //V = S * D --> vector direction is downward and the speed is 4;
            rb.velocity = Vector2.down * speedOfBall;
            
        }
    }
}
