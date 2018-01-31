using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuMu : MonoBehaviour
{
    Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessInput();
	}

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up);
        }

        if(Input.GetKey(KeyCode.A))
        {
            print("Rotate left");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            print("Rotate right");
        }
        else if (Input.GetKey(KeyCode.W))
        {
            print("Go up");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            print("Go down");
        }
    }
}
