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
        if (collider.CompareTag("Crate"))
        {
            //add list thingy here
            inRange = true;
            addObject();
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
        }
    }

    public void addObject()
    {
        if (inRange)
        {
            boxes = new List<GameObject>();
            boxes.Add(gameObject);

        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Crate"))
        {
            boxes.Remove(gameObject);
        }
    }


}
