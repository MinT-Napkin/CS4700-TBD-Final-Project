using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour, InteractInterface{
    public string description;
    new public string name;
    public ItemCategories category;
    public CircleCollider2D circleCollider;
    public Entity entity;
    public PlayerClass player;

    public virtual void Awake(){
        gameObject.layer = LayerMask.NameToLayer("Interactable");
        player = GameObject.FindWithTag("Player").GetComponent<PlayerClass>();
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
    }


    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public virtual void CurrentViewTarget(){

    }

    public virtual void InteractWithTarget(Entity entity){
        this.entity = entity;
        entity.inventory.AddToInventory(this, 1);
        Debug.Log(name + " added to inventory.");
        Destroy(gameObject);
    }

    public virtual void Use(){
    }
}
