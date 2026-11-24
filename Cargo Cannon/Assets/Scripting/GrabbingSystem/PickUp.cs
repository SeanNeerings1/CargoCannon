using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class PickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool grabbed;
    private bool holding;
    private bool inRange;

    [SerializeField] private float _distance;

    [SerializeField] private GameObject _player;
    //[SerializeField] private GameObject _box;

    //possibly use a raycast system with this

    //collider
    //compare tag crate (with an object list)
    //collision.getcomponent and check the crateID
    //also get the rigidbody of said crates
    //physics based force that pushes the crate up 
    //a boolean for grabbing and player input that trigger said boolean


    //turn into raycast
    /*
    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Box"))
        {
            inRange = true;
            if (Input.GetKey(KeyCode.E) && !holding && inRange)
            {
                grabbed = true;
                    //Transform() within the () place a SetParent or tranform.SetParent()
            }
        }
    }

    /*

     RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

    */

    private void Update()
    {
        Grab();
    }

    public void Grab()
    {

        Debug.DrawRay(transform.position, transform.forward * _distance, Color.green);
        //visualisation of the raycast
        RaycastHit hit;
       if(Physics.Raycast(transform.position, transform.forward, out hit, _distance) && Input.GetKey(KeyCode.E) && !holding)
        {
            //_player.transform.parent = _box.transform; //double check this

            print(hit.collider.gameObject.name);
            if(hit.collider.gameObject.tag == "PickUp")
            {
                hit.transform.parent = _player.transform;
                Rigidbody rb =  hit.collider.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = false;
                holding = true;

            }
            if (Input.GetKey(KeyCode.Q)) //drop doesn't work due to if statement conditions so make it apart from it
            {
                hit.transform.parent = null;
                holding = false;
            }

        }
        
        
            //  Transform.SetParent();
            
         //might have to make a status class for the player and return a true value otherwise you'd be able to grab multiple boxes at once
    }
    

    public void drop()
    {

    }

    
    /*
   //turn into raycast
    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Box"))
        {
            inRange = false;
        }
    }
    */

}
