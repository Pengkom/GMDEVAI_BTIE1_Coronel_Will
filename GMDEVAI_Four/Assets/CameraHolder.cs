using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHolder : MonoBehaviour
{
    //Take in empty child object for Camera Position
    public Transform PlayerCameraPosition;
    
    void LateUpdate()
    {
        //Set Holder position to Player Camera Position
        transform.position = PlayerCameraPosition.position;
    }
}
