using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    //Variable1: the pink circle object
    public GameObject pinkBaitPrefab;

    //Variable2: pink bait ball should be in the point of the fishing pole
    public Transform spawnPoint;

    //Variable3: the speed of the ball falling down is 4.
    public float speedOfBall = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //if the user presses down the space key, run the spawnBait function.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBait();
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
