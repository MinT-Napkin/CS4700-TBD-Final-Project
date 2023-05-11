using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour{

    public List<KeyValuePair<ItemParent, int>> inventory = new List<KeyValuePair<ItemParent, int>>();
    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update() {
    }

    public List<KeyValuePair<ItemParent, int>> GetInventory(){
        return inventory;
    }

    public void AddToInventory(ItemParent itemAdded, int quantity){
        bool keyExists = false;

        Debug.Log(inventory.Count);
        for (int i = 0; i < inventory.Count; i++){
            Debug.Log(inventory[i]);
            if (inventory[i].Key.GetType() == itemAdded.GetType()){
                keyExists = true;

                inventory[i] = new KeyValuePair<ItemParent, int>(itemAdded, (inventory[i].Value + quantity));
            }
        }

        Debug.Log("keyExists = " + keyExists + ". This means the item did not previously exist in the inventory");

        if (!keyExists){
            inventory.Add(new KeyValuePair<ItemParent, int>(itemAdded, quantity));
        }

        Debug.Log("From the Inventory: Item at index 0: " + inventory[0].Key + " of quantity " + inventory[0].Value + "\n and from the Getter Method: " + GetInventory()[0].Key + " of quantity " + GetInventory()[0].Value);

        /*if (inventory.ContainsKey(itemAdded)){
            inventory[itemAdded] += quantity;
        }
        else{
            inventory.Add(itemAdded, quantity);
        }*/
    }

    public void RemoveFromInventory(ItemParent itemRemoved, int quantity){
        for (int i = 0; i < inventory.Count; i++){
            if (inventory[i].Key == itemRemoved){
                if (inventory[i].Value >= quantity){
                    inventory[i] = new KeyValuePair<ItemParent, int>(itemRemoved, (inventory[i].Value - quantity));

                    if (inventory[i].Value == 0){
                        inventory.RemoveAt(i);
                    }
                }
                else{
                    Debug.Log("Invalid Operation. Not enough " + itemRemoved.name + " in inventory");
                }

                //inventory[i] = new KeyValuePair<ItemParent, int>(itemRemoved, (inventory[i].Value + quantity));
            }
        }

        /*if (inventory.ContainsKey(itemRemoved)){
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
        }*/
    }
}
