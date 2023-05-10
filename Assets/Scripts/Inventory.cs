using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private KeyValuePair<ItemParent, int>[] inventory = new KeyValuePair<ItemParent, int>[30];
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }

    public KeyValuePair<ItemParent, int>[] GetInventory() {
        return inventory;
    }

    public void AddToInventory(ItemParent itemAdded, int quantity) {
        int index = 0;
        bool keyExists = false;

        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i].Key == itemAdded) {
                keyExists = true;

                inventory[i] = new KeyValuePair<ItemParent, int>(itemAdded, (inventory[i].Value + quantity));
            }

            if (inventory[i].Key != null) {
                index++;
            }
        }

        if (!keyExists) {
            inventory[index] = new KeyValuePair<ItemParent, int>(itemAdded, quantity);
        }

        /*if (inventory.ContainsKey(itemAdded)){
            inventory[itemAdded] += quantity;
        }
        else{
            inventory.Add(itemAdded, quantity);
        }*/
    }

    public void RemoveFromInventory(ItemParent itemRemoved, int quantity) {
        for (int i = 0; i < inventory.Length; i++) {
            if (inventory[i].Key == itemRemoved) {
                if (inventory[i].Value >= quantity) {
                    inventory[i] = new KeyValuePair<ItemParent, int>(itemRemoved, (inventory[i].Value + quantity));

                    if (inventory[i].Value == 0) {
                        inventory[i] = new KeyValuePair<ItemParent, int>(null, -1);
                    }
                }
                else {
                    Debug.Log("Invalid Operation. Not enough " + itemRemoved.name + " in inventory");
                }

                inventory[i] = new KeyValuePair<ItemParent, int>(itemRemoved, (inventory[i].Value + quantity));
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
