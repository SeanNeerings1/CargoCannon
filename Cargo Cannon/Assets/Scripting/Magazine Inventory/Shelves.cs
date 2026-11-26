using UnityEngine;
using System.Collections.Generic;

public class Shelves : MonoBehaviour
{
    List<BoxInfo> shelfInventory = new List<BoxInfo>();

    void Update()
    {
        //Count amount and update models + error management for overflow
    }

    void AddProduct(BoxInfo item)   //add product to shelf
    {     
        if(shelfInventory.Count + 1 > 9) //Check if there is enough space on shelf for new product
        {        
           
                shelfInventory.Add(item);      
        }
        else
        {
            Debug.Log("Not enough space on shelf for " + item.Name);
        }
    }

    void DisplayProducts()  //display products in shelf visually
    {

    }
}
