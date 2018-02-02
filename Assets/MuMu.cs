using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MuMu : MonoBehaviour
{
    [SerializeField] float MuMuRotateEnergy = 200f;
    [SerializeField] float MuMuFlyEnergy = 30f;

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
        Rotate();
        Fly();
	}

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do nothing
                print("OK");
                break;
            case "Finish":
                SceneManager.LoadScene(1);
                break;
            case "Food":
                print("Food");
                break;
            default:
                SceneManager.LoadScene(0);
                break;;
        }
    }

    private void Rotate()
    {
        rigidbody.freezeRotation = true; //take manual control of rotation

        float rotationThisFrame = MuMuRotateEnergy * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidbody.freezeRotation = false;
    }

    private void Fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * MuMuFlyEnergy);
            if (!audioSource.isPlaying) //if space is already pressed, it doesn't layer
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
