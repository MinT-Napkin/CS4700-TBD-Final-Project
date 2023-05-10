using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour{

    private SortedList<ItemParent, int> inventory = new SortedList<ItemParent, int>();
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public SortedList<ItemParent, int> GetInventory(){
        return inventory;
    }

    public void AddToInventory(ItemParent itemAdded, int quantity){
        if (inventory.ContainsKey(itemAdded)){
            inventory[itemAdded] += quantity;
        }
        else{
            inventory.Add(itemAdded, quantity);
        }
    }

    public void RemoveFromInventory(ItemParent itemRemoved, int quantity){
        if (inventory.ContainsKey(itemRemoved)){
            if (inventory[itemRemoved] >= quantity){
                inventory[itemRemoved] -= quantity;

                if (inventory[itemRemoved] == 0){
                    inventory.Remove(itemRemoved);
                }
            }
            else{
                Debug.Log("Invalid Operation. Not enough " + itemRemoved.name + " in inventory");
            }
        }
        else
        {
            Debug.Log("Invalid Operation. No Such Key");
        }
    }
}
