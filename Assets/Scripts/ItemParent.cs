using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour, Interactable{
    public string description;
    new public string name;
    public ItemCategories category;
    public int quantity;
    public PlayerClass player;
    public CircleCollider2D circleCollider;

    public virtual void Awake()
    {
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        player = GameObject.FindWithTag("Player").GetComponent<PlayerClass>();
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
    }

    public void Interact()
    {
        player.inventory.AddToInventory(this, quantity);
        Debug.Log(name + " added to inventory.");
        Destroy(gameObject);
    }

    public virtual void Use(){
        //Item usage
    }
}
