using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool grabbed;
    private bool inRange;
    private List<GameObject> boxes;

    //collider
    //compare tag crate (with an object list)
    //collision.getcomponent and check the crateID
    //also get the rigidbody of said crates
    //physics based force that pushes the crate up 
    //a boolean for grabbing and player input that trigger said boolean

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = true;
            if(inRange)
            if (Input.GetKey(KeyCode.E))
            {
                grabbed = true;
            }
        }
    }
    


    public void Grab()
    {
        if (grabbed)
        {
            //make the box a part of the player through parent child relations of objects
        } //might have to make a status class for the player and return a true value otherwise you'd be able to grab multiple boxes at once
    }

    

    
    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            inRange = false;
        }
    }


}
