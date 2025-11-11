using UnityEngine;

public class FishMovement : MonoBehaviour
{

    //FIRST THE VARIABLES ARE CREATED
    //Variable 1: What should the speed of the fish be? 
    //floats to create smooth speeds and not choppy
    public float swimSpeed = 2f;
    //Variable 2: How far to the left and right should the fish swim before flipping.
    public float swimDistance = 5f;
    //Varible 3: Keeps the starting position of the fish (start off): X,Y,Z coordinates (1,0,0)
    //Last two are private so they don't get changed outside of this script
    private Vector3 startPoint;
    //Variable 4: Determine the direction that the fish will be swiming: 1 is right, -1 is left
    private int direction = 1;



    // Start is called before the first frame update
    void Start()
    {
        //this remembers where the fish began so it can track how far it can swim. 
        startPoint = transform.position;
    }



    // Update is called once per frame
    void Update()
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
    
    //function "FlipFish" is what gets called to flip the sprite so the swimming looks realistic.
    void FlipFish()
    {
        //grab the current scale of the fish and store into currScale
        Vector3 currScale = transform.localScale;

        //Flip the x scale (multiply by -1 to flip on the horizontal) using the scale will mirror the size of the fish
        currScale.x *= -1;

        //add the flipped scale back into the fish so currScale.
        transform.localScale = currScale;
    }
}
