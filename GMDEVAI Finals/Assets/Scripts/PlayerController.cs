using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject sneakText;
    
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float defaultSpeed;
    [SerializeField] private float currentSpeed;
    
    public bool sneaking = false;
    private float sneakSpeed;
    
    private void Start()
    {
        Application.targetFrameRate = 60;
        
        currentSpeed = defaultSpeed;
        sneakSpeed = defaultSpeed / 2;
    }

    private void LateUpdate()
    {
        Sneak();
        WASDMovement();
    }

    private void WASDMovement()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);

        float vertical = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);
    }
    
    private void Sneak()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl))
        {
            sneakText.SetActive(true);
            currentSpeed = sneakSpeed;
            sneaking = true;
        }
        else
        {
            sneakText.SetActive(false);
            currentSpeed = defaultSpeed;
            sneaking = false;
        }
    }
}