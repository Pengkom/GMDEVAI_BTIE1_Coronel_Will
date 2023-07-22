using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    
    //Take player orientation via Orientation empty object
    public Transform orientation;
    
    private float horizontalInput;
    private float verticalInput;
    
    private Vector3 moveDirection;
    
    private Rigidbody _rigidbody;

    void Start()
    {
        //Set rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        //Stop capsule from toppling
        _rigidbody.freezeRotation = true;
        Application.targetFrameRate = 60;
    }

    private void LateUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MyInput()
    {
        //Receive keyboard
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    
    private void MovePlayer()
    {
        MyInput();
        
        //Front depends on where player is looking
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        
        //Move maths
        _rigidbody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    private void JumpPlayer()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce((transform.up * moveSpeed) * 0.8f, ForceMode.VelocityChange);
        }
    }
    
}
