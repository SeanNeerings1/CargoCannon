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

    
    [SerializeField] private GameObject _boxPosition;
    private GameObject _holdingBoxObject;
    private BoxInfo _holdingBoxInfo;
    
    
    //Currently need an empty that's always stuck on the end of the raycast, then parent the box to said empty

    private void Update()
    {
        Grab();
        if (Input.GetKey(KeyCode.Q)) //drop doesn't work due to if statement conditions so make it apart from it
        {
            drop();
        }
    }

    public void Grab()
    {

        Debug.DrawRay(transform.position, transform.forward * _distance, Color.green);
        //visualisation of the raycast
        RaycastHit hit;
       if(Physics.Raycast(transform.position, transform.forward, out hit, _distance) && Input.GetKey(KeyCode.E) && !holding)
        {
            //_player.transform.parent = _box.transform; //double check this

            if(hit.collider.gameObject.tag == "PickUp")
            {
                hit.transform.parent = _boxPosition.transform;
                Rigidbody rb =  hit.collider.gameObject.GetComponent<Rigidbody>();
                rb.isKinematic = true;
                //rb.useGravity = false;
                holding = true;

                _holdingBoxInfo = hit.collider.gameObject.GetComponent<BoxInfo>();
                _holdingBoxObject = hit.collider.gameObject;

                //testing Natan
                if(_holdingBoxInfo.BoxPrefab != _holdingBoxObject)
                {
                    Debug.LogError("BoxPrefab and BoxObject are NOT the same!!!!");
                }
                
            }
            

        }
        
        
            //  Transform.SetParent();
            
         //might have to make a status class for the player and return a true value otherwise you'd be able to grab multiple boxes at once
    }
    

    public void drop()
    {

        Rigidbody rb = _holdingBoxObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;

        _holdingBoxObject.transform.parent = null;
        _holdingBoxInfo = null;
        holding = false;
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
