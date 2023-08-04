using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMovement : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 5;

    void LateUpdate()
    {
        // Mouse Look
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);

        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical);
    }
}
