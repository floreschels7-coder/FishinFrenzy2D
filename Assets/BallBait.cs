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
            if (fish.Contains(otherObject.gameObject))
            {
                return;
            }
            fish.Add(otherObject.gameObject);

            otherObject.gameObject.transform.parent = this.transform;

            FishMovement fishMovement = otherObject.GetComponent<FishMovement>();
            if(fishMovement != null)
            {
                fishMovement.enabled = false;
            }

            Collider2D fishCollider = otherObject.GetComponent<Collider2D>();
            if(fishCollider != null)
            {
                fishCollider.enabled = false;
            }

            //That is essentially earning 1 point that will get added to the total score
            //calls ScoreTracker class instance variable adds points. 
            ScoreTracker.instance.AddScore(1);

            //Find the GameManager object and get its GameOver script
            //Then tell it a fish was caught
            GameObject.Find("GameManager").GetComponent<GameOver>().FishisCaught();
        }
    }

    public void setFishing(bool isFishing)
    {
        controller.isFishing = isFishing; 
    }
}
