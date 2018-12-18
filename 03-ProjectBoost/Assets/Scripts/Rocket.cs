using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private const string THRUST_BUTTON = "Jump";
    private const string ROTATION_AXIS = "Horizontal";

    [SerializeField] int thrust = 20;
    [SerializeField] int torque = 10;

    [Header("Sounds")]
    [SerializeField] AudioClip thrustSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip levelLoadSound;

    [Header("Particles")]
    [SerializeField] ParticleSystem thrustEffect;
    [SerializeField] ParticleSystem deathEffect;
    [SerializeField] ParticleSystem levelLoadEffect;

    new private Rigidbody rigidbody;
    private AudioSource audioSource;
    private Level level;
    private bool transitioning = false;
    private bool collisionsDisabled = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        level = FindObjectOfType<Level>();
    }

    void Update()
    {
        if (transitioning)
        {
            return;
        }
        moveUp();
        if (Input.GetButton(ROTATION_AXIS))
        {
            rotate();
        }
        if (Debug.isDebugBuild)
        {
            processDebugKeys();
        }
    }

    private void moveUp()
    {
        if (Input.GetButton(THRUST_BUTTON))
        {
            applyThrust();
        }
        else
        {
            stopApplyingThrust();
        }
    }

    private void applyThrust()
    {
        rigidbody.AddRelativeForce(Vector3.up * thrust);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(thrustSound);
        }
        thrustEffect.Play();
    }

    private void rotate()
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.back * Input.GetAxis(ROTATION_AXIS) * torque * Time.deltaTime);
        rigidbody.freezeRotation = false;
    }

    private void processDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            level.loadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsDisabled = !collisionsDisabled;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (transitioning || collisionsDisabled)
        {
            return;
        }
        stopApplyingThrust();
        if (other.gameObject.tag == "Finish")
        {
            loadNextLevel();
        }
        else if (other.gameObject.tag != "Friendly")
        {
            resetLevel();
        }
    }

    private void stopApplyingThrust()
    {
        audioSource.Stop();
        thrustEffect.Stop();
    }

    private void loadNextLevel()
    {
        transitioning = true;
        audioSource.PlayOneShot(levelLoadSound);
        levelLoadEffect.Play();
        level.loadNext();
    }

    private void resetLevel()
    {
        transitioning = true;
        audioSource.PlayOneShot(deathSound);
        deathEffect.Play();
        level.reset();
    }
}
