﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private const string THRUST_BUTTON = "Jump";

    [SerializeField] int thrust = 20;
    [SerializeField] int torque = 10;

    new private Rigidbody rigidbody;
    private AudioSource audioSource;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        move();
        playSound();
    }

    private void move()
    {
        if (Input.GetButton(THRUST_BUTTON))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrust);
        }
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.back * Input.GetAxis("Horizontal") * torque * Time.deltaTime);
        rigidbody.freezeRotation = false;
    }

    private void playSound()
    {
        if (Input.GetButtonDown(THRUST_BUTTON))
        {
            audioSource.Play();
        }
        if (Input.GetButtonUp(THRUST_BUTTON))
        {
            audioSource.Stop();
        }
    }
}
