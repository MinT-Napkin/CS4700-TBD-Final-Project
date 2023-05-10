using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(24);
    public PlayerClass player;
    public GameObject slotPrefab;

    void ClearInventory(){
        foreach (Transform transform in transform) {
            Destroy(transform.gameObject);
        }

        new List<InventorySlot>(24);
    }

    public void ConstructPanel(){
        KeyValuePair<ItemParent, int>[] itemClasses = player.inventory.GetInventory();

        gameObject.GetComponent<Image>().enabled = true;

        for (int i = 0; i < inventorySlots.Capacity; i++) {
            CreateInventorySlot();
        }

        for (int i = 0; i < itemClasses.Length; i++){
            if (itemClasses[i].Key != null) {
                inventorySlots[i].ConstructSlot(itemClasses[i].Key, itemClasses[i].Value);
                inventorySlots[i].SetPlayer(player);
            }
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
        GameObject slot = Instantiate(slotPrefab);

        slot.transform.SetParent(transform, false);

        InventorySlot slotComponent = slot.GetComponent<InventorySlot>();
        slotComponent.ClearSlot();

        inventorySlots.Add(slotComponent);
    }
}
