using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void OnTriggerEnter2D(Collider2D otherObject)
    {
        //if this 'otherObject' falls into the "Bait" category then...
        if (otherObject.CompareTag("Bait"))
            {
                BallBait bait = otherObject.gameObject.GetComponent<BallBait>();
                bait.setFishing(false); 
            }
    }
}
