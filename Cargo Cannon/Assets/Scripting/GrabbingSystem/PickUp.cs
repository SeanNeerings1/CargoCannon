using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool inRange;
    private bool grabbed;

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
        }
    }


    public void Grab()
    {

    }


}
