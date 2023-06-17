using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseLook : MonoBehaviour
{
    //Sensitivity
    public float sensX;
    public float sensY;

    //Take player orientation via Orientation empty object
    public Transform orientation;
    
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        //Lock cursor to window & hide cursor (Might be redundant)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void LateUpdate()
    {
        //Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        //Maths
        yRotation += mouseX;
        //Stop player from looking 360 up or down
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        xRotation -= mouseY;

        //Camera
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
