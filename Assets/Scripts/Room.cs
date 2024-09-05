using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera roomVCam;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collision Detected");
        if (collider.transform.GetComponent<PlayerScript>() == true)
        {
            roomVCam.Priority = 20;
            
        }
    
}

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("Collision Detected");
        if (collider.transform.GetComponent<PlayerScript>() == true)
        {
            roomVCam.Priority = 1;
        
    }
}
    private void OnTriggerStay(Collider collider)
    {
        
    }
    // Start is called before the first frame update
}
