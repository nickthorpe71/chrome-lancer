using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour
{
    public float speed = 110f;
    public float hoverForce = 165f;
    public float hoverHeight = 3.5f;

    private float powerInput = 1;
    private Rigidbody bikeRigidbody;

    private void Awake()
    {
        bikeRigidbody = GetComponent<Rigidbody>();
    }

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        powerInput = 1;
    //    }
    //    else
    //    {
    //        powerInput = 0;
    //    }
    //}

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            bikeRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration); //ForceMode.Acceleration ignores mass of the bike
        }

        bikeRigidbody.AddRelativeForce(powerInput * speed, 0f, 0f);
    }
}
