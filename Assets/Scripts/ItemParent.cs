using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour, InteractInterface{
    public string description;
    new public string name;
    public ItemCategories category;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    public virtual void CurrentViewTarget(){

    }

    public virtual void InteractWithTarget(Entity entity){

    }
}
