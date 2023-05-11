using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour, InteractInterface{
    public string description;
    new public string name;
    public ItemCategories category;
    public CircleCollider2D circleCollider;
    public Sprite sprite;
    public TextSystemUI textSystem;

    public virtual void Awake(){
        gameObject.layer = LayerMask.NameToLayer("Interactable");
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
        entity.inventory.AddToInventory(this, 1);

        Debug.Log("From the Item: " + name + " added to inventory of " + entity.GetInstanceID());

        textSystem.enableText();

        textSystem.setTextIn(name + " added to inventory.");

        Destroy(gameObject);
    }

    public virtual void Use(Entity entity){
    }

    IEnumerator WaitForSec(){
        yield return new WaitForSeconds(2);
        textSystem.disableText();
    }
}
