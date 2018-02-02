using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuMu : MonoBehaviour
{
    Rigidbody rigidbody;
    private AudioSource audioSource;

    // Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();    
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
            if (!audioSource.isPlaying) //if space is already pressed, it doesn't layer
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward);
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
