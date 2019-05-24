using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName; //inout info
    [SerializeField] private float mouseSensitivity; // input info

    [SerializeField] private Transform playerBody; // for the player

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();// calls function
        xAxisClamp = 0.0f;
    }
    //for the mouse so you cant look up and down 
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        PlayerRotation(); //calles player rotation function 
    }
    private void PlayerRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime; //this is so we dont whip around that much. 

        //parameters for x axis 
        if (xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
           
            ClampXAxisRotationToValue(270.0f);
        }
        else if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            
            ClampXAxisRotationToValue(90.0f);
        }

        
        playerBody.Rotate(Vector3.up * mouseX); //lets the player rotate.
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
