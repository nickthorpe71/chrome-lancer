using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour
{
    public float speed = 90f;
    public float hoverForce = 65f;
    public float hoverHeight = 3.5f;

    private float powerInput;
    private Rigidbody bikeRigidbody;

    private void Awake()
    {
        bikeRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            powerInput = 1;
        }
        else
        {
            powerInput = 0;
        }
    }

    private void FixedUpdate()
    {
        
    }
}
