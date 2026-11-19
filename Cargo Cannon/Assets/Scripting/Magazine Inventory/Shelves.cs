using UnityEngine;
using System.Collections.Generic;

public class Shelves : MonoBehaviour
{
    List<Product> shelfInventory = new List<Product>();
    int itemPerBox = 4; //how many items can be stored in one box

    void Update()
    {
        //Count amount and update models + error management for overflow
    }

    void AddProduct(Product item)   //add product to shelf
    {
        //Check if item already exists in shelf inventory
        int existingAmount = 0;
        foreach (Product p in shelfInventory)
        {
            if (p.Name == item.Name)
            {
                existingAmount = p.Amount;
            
                break;
            }
        }
        int existingSpots = existingAmount / itemPerBox;
   
        //Count how many spots product takes
        int itemSpots = (existingAmount + item.Amount) / itemPerBox;

        if(itemSpots < (9 - shelfInventory.Count) + existingSpots) //Check if there is enough space on shelf for new product
        {
            if (existingAmount > 0) //if item already exists in shelf inventory
            {
                foreach (Product p in shelfInventory) //repeat till to fill every spot with the max amount of items per box
                {
                    if (p.Name == item.Name)
                    {
                        if(p.Amount < itemPerBox)   //if the box is not full yet
                        {
                            int spaceLeft = itemPerBox - p.Amount;
                            if (item.Amount <= spaceLeft)   //add rest if its the last few items
                            {
                                p.Amount += item.Amount;
                                item.Amount = 0;
                            }
                            else       //Add max amount of items to box and continue to next box
                            {
                                p.Amount += spaceLeft;
                                item.Amount -= spaceLeft;
                            }
                        }
                    }
                }

                //if there are still items left to add after filling existing boxes, fill them
                if(item.Amount > 0) //if there are still items left to add after filling existing boxes
                {
                    int spotsLeft = item.Amount / itemPerBox; //calculate how many full boxes can be added
                    for(int i = 0; i < spotsLeft; i++) //add full boxes
                    {
                        int amountToAdd = itemPerBox;
                        if(item.Amount < itemPerBox) //if there are less items left than a full box
                        {
                            amountToAdd = item.Amount; //add the remaining items
                        }
                        Product newProduct = new Product();
                        newProduct.Name = item.Name;
                        newProduct.Amount = amountToAdd;
                        shelfInventory.Add(newProduct);
                    }
                }
            }
            else //if item does not exist in shelf inventory
            {
                int spotsLeft = item.Amount / itemPerBox; //calculate how many full boxes can be added
                for(int i = 0; i < spotsLeft; i++) //add full boxes
                {
                    int amountToAdd = itemPerBox;
                    if(item.Amount < itemPerBox) //if there are less items left than a full box
                    {
                        amountToAdd = item.Amount; //add the remaining items
                    }
                    Product newProduct = new Product();
                    newProduct.Name = item.Name;
                    newProduct.Amount = amountToAdd;
                    shelfInventory.Add(newProduct);
                }
            }
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

public class Product
{
    public string Name;
    public int Amount;
    int Value; 
    string[] StorageTags; //empty normal, else it needs to be stored in a funky way
    int SpoilTimer; //if >0 and no special tag then count down, if -1 can not spoil

    public void product(string name, int amount, int value, string[] storageTags, int spoilTimer)
    {
        Name = name;
        Amount = amount;
        Value = value;
        StorageTags = storageTags;
        SpoilTimer = spoilTimer;
    }
}
