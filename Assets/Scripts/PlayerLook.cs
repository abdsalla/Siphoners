using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        PlayerRotation();
    }
    private void PlayerRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        

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

        
        playerBody.Rotate(Vector3.up * mouseX);
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
