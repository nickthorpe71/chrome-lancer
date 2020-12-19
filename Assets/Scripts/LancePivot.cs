using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancePivot : MonoBehaviour
{
    public float zPivot = -90.0f;
    public float yPivot = -20.0f;

    public float turnSpeed = 1.0f; //adjust this value to get a faster rotation speed.
    float rotation;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rotation = 1 * turnSpeed;
            transform.Rotate(new Vector3 (transform.rotation.x, transform.rotation.y, transform.rotation.z + 1) , rotation);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rotation = -1 * turnSpeed;
            transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 1), rotation);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = 1 * turnSpeed;
            transform.Rotate(transform.up, rotation);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = -1 * turnSpeed;
            transform.Rotate(transform.up, rotation);
        }
    }

    
}
