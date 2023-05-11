using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(24);
    public GameObject slotPrefab;

    void ClearInventory(){
        foreach (Transform transform in transform){
            Destroy(transform.gameObject);
        }

        inventorySlots = new List<InventorySlot>(24);
    }

    public void ConstructPanel(PlayerClass player){
        List<KeyValuePair<ItemParent, int>> inventoryList = new List<KeyValuePair<ItemParent, int>>(player.inventory.GetInventory());
        Debug.Log("From the Inventory Panel UI: Item at index 0: " + inventoryList[0].Key + " in inventory of " + player.GetInstanceID());
        gameObject.GetComponent<Image>().enabled = true;

        for (int i = 0; i < 24; i++){
            CreateInventorySlot();
        }
        Debug.Log("Count: " + inventoryList.Count + " Capacity " + inventoryList.Capacity);
        for (int i = 0; i < inventoryList.Count; i++){
            Debug.Log("From the Inventory Panel UI: Index: " + i + " stores item " + inventoryList[i].Key + " of quantity " + inventoryList[i].Value);
            inventorySlots[i].ConstructSlot(inventoryList[i].Key, inventoryList[i].Value);
        }
    }

    public void DestructPanel(){
        /*foreach(InventorySlot slot in inventorySlots){
            Destroy(slot.gameObject);
        }*/

        ClearInventory();

        gameObject.GetComponent<Image>().enabled = false;
    }

    void CreateInventorySlot(){
        GameObject slot = Instantiate<GameObject>(slotPrefab, transform);

        InventorySlot slotComponent = slot.GetComponent<InventorySlot>();
        slotComponent.ClearSlot();

        inventorySlots.Add(slotComponent);
    }
}
