﻿using System;
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

    enum State {Alive, Dying, Transcending}
    State state = State.Alive;

    //Use this for initialization
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();    
    }
	
	//Update is called once per frame
	void Update ()
    {
        //todo somewhere stop the sound
        if (state == State.Alive) //if not alive, cannot move (do anything)
        {
            Rotate();
            Fly();
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        if (state != State.Alive) { return; } //if not alive, method stops here

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                print("OK"); //todo do nothing
                break;
            case "Finish":
                state = State.Transcending; //reloading with delay, doesn't open immediately
                Invoke("LoadNextScene", 1f);
                break;
            case "Food":
                print("Food");
                break;
            default:
                state = State.Dying;
                Invoke("LoadFirstLevel", 1f); //1f = 1 sec
                break;;
        }
    }

    private void LoadFirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(1); //todo more than 2 levels
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
