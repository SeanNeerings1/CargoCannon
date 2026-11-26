using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Experimental.GlobalIllumination;

public class Shelves : MonoBehaviour
{
    [SerializeField] private GameObject shelfPrefab; //the model of the shelf, used to display the products on it
    Dictionary<Vector3, BoxInfo> shelfPositions = new Dictionary<Vector3, BoxInfo>(); //the positions on the shelf where products can be placed
    void Start()
    {
        //Initialize shelf positions
        for (int i = 1; i <= 9; i++)
        {
            Transform childTransform = shelfPrefab.transform.Find("Spot " + i);
            Vector3 localPosition = childTransform.localPosition;
            shelfPositions.Add(localPosition, null); //initialize the position with no product
        }
    }

    public bool AddProduct(BoxInfo item)   //add product to shelf
    {     
        foreach(var spot in shelfPositions)
        {
            if(spot.Value == null) //Check if the spot is empty
            {
                shelfPositions[spot.Key] = item;

                //Instantiate the product on the shelf
                GameObject productInstance = Instantiate(item.BoxPrefab, shelfPrefab.transform);
                productInstance.transform.localPosition = spot.Key; //Set the local position to the shelf spot
                
                shelfPositions[spot.Key] = item; //Update the dictionary to reflect that the spot is now occupied

                return true;
            }
        }
       
        
            Debug.Log("Not enough space on shelf for " + item.Name);
            return false; //Not enough space on shelf
        
    }

    void DisplayProducts()  //display products in shelf visually
    {

    }
}
