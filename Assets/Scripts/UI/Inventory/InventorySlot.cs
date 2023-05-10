using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour{
    public Image icon;
    public TextMeshProUGUI itemQuantity;
    public PlayerClass player;

    public void ClearSlot(){
        icon.enabled = false;
        itemQuantity.enabled = false;
    }

    public void ConstructSlot(ItemParent item, int quantity){
        icon.enabled = true;
        itemQuantity.enabled = true;

        icon.sprite = item.sprite;
        itemQuantity.text = quantity.ToString();
    }

    public void SetPlayer(PlayerClass player){
        this.player = player;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
