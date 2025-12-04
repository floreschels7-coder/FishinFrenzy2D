using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallBait : MonoBehaviour
{

   public List<GameObject> fish = new List<GameObject>();
   public FishController controller;



    void OnTriggerEnter2D(Collider2D otherObject)
    {
        //if this 'otherObject' falls into the "Fish" category then...
        if (otherObject.CompareTag("Fish"))
        {
            //check if we already caught this fish
            if (fish.Contains(otherObject.gameObject))
            {
                return; //return if fish is already caught
            }

            //Add this fish to the caught fish catergory
            fish.Add(otherObject.gameObject);

            //make the fish stick to pink ball 
            otherObject.gameObject.transform.parent = this.transform;

            //grabs the Fish script for the Fast and Normal fish
            Fish fishScript = otherObject.GetComponent<Fish>();

            if(fishScript != null)
            {
                //disable fish's movement script to make it quit swimming
                fishScript.enabled = false;

                //get score from the fish and add
                //Fast fish are 20 and normal fish are 10
                ScoreTracker.instance.AddScore(fishScript.scoreValue);
            }

            //fish's collider component
            Collider2D fishCollider = otherObject.GetComponent<Collider2D>();
            if(fishCollider != null)
            {
                //disable collider so fish isn't caught again twice.
                fishCollider.enabled = false; 
            }

            //Find the GameManager object and get its GameOver script
            //Then tell it a fish was caught (to check if game shoudl end)
            GameObject.Find("GameManager").GetComponent<GameOver>().FishisCaught();
        }
    }

    public void setFishing(bool isFishing)
    {
        controller.isFishing = isFishing; 
    }
}
