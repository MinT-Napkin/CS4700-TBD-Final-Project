using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour{
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(24);
    public PlayerClass player;
    public GameObject slotPrefab;

    void ClearInventory(){
        foreach (Transform transform in transform){
            Destroy(transform.gameObject);
        }

        new List<InventorySlot>(24);
    }

    void ConstructPanel(){
        //SortedDictionary<ItemParent, int> itemClasses = player.inventory.GetInventory();

        for (int i = 0; i < inventorySlots.Capacity; i++){
            CreateInventorySlot();
        }

        //for (int i = 0; i < itemClasses.Count; i++){
            //inventorySlots[i].ConstructSlot(itemClasses.GetKey(i))
        //}
    }

    void CreateInventorySlot(){
        GameObject slot = Instantiate(slotPrefab);

        slot.transform.SetParent(transform, false);

        InventorySlot slotComponent = slot.GetComponent<InventorySlot>();
        slotComponent.ClearSlot();

        inventorySlots.Add(slotComponent);
    }
}
