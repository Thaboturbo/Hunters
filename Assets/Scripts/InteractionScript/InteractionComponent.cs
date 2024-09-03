using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionComponent : MonoBehaviour

{

    public float destroyDelay = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InteractionExecuted() 
    {
    Debug.Log("Player interacted with "+ gameObject.name);
        Destroy(gameObject, destroyDelay);
        
    }
}
