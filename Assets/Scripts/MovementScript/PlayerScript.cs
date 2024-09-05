using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Vector2 movementInput;
    public float movementSpeed;

    public float gravity = 9.8f;
    public float jumpSpeed = 5f;
    public float verticalSpeed = 0;
    public Cinemachine.CinemachineVirtualCamera playerCamera ;

    public float rayLength = 10f;
    public void IAMovement(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

    }

    public void IAJump(InputAction.CallbackContext context)
    {
        if (context.started == true && GroundCheck() == true)
        {
            verticalSpeed = jumpSpeed;
        }

    }
    public void IAInteract(InputAction.CallbackContext context)
    {
        if( context.started == true) 
        {
            InteractionRayCast();
        }

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GroundCheck() == true && verticalSpeed <= 0)
        {
            verticalSpeed = 0;


        }
        else
        {
            verticalSpeed = verticalSpeed - gravity * Time.deltaTime;
        }

        transform.Translate(movementInput.x * movementSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime, movementInput.y * movementSpeed * Time.deltaTime);


    }

    public bool GroundCheck()
    {

        return Physics.Raycast(transform.position, transform.up * -1, 1.1f);
    }
    public void InteractionRayCast()
     {
     Vector3 myPosition = transform.position;
        Vector3 CameraDirection= Camera.main.transform.forward;


        Ray InteractionRay = new Ray(playerCamera.transform.position, CameraDirection);
        
        RaycastHit targetInfo;

        if (Physics.Raycast(InteractionRay, out targetInfo, rayLength)== true)
        {

            Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + (CameraDirection * rayLength), Color.green, 3f);

            if (targetInfo.transform.gameObject.GetComponent<InteractionComponent>()== true )
            {
                targetInfo.transform.gameObject.GetComponent<InteractionComponent>().InteractionExecuted();

            }
            else
            {
                Debug.Log("Hit object does not have interaction component");
            }
        }
        else 
        {
            Debug.DrawLine(playerCamera.transform.position, playerCamera.transform.position + (CameraDirection * rayLength), Color.red, 3f);
        }
        
    }
}
