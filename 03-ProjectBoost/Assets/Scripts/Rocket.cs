using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private const string THRUST_BUTTON = "Jump";
    private const float DISTANCE_FROM_PAD = 2.5f;

    [SerializeField] int thrust = 20;
    [SerializeField] int torque = 10;
    [SerializeField] float levelLoadDelay = 1;

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
    private int currentSceneIndex;
    private State state = State.Alive;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (state != State.Alive)
        {
            return;
        }
        moveUp();
        rotate();
    }

    private void moveUp()
    {
        if (Input.GetButton(THRUST_BUTTON))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrust);
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustSound);
            }
            thrustEffect.Play();
        }
        else
        {
            stopAudioAndThrustEffect();
        }
    }

    private void rotate()
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.back * Input.GetAxis("Horizontal") * torque * Time.deltaTime);
        rigidbody.freezeRotation = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (state != State.Alive)
        {
            return;
        }
        stopAudioAndThrustEffect();
        if (other.gameObject.tag == "Finish")
        {
            loadNextLevel();
        }
        else if (other.gameObject.tag != "Friendly")
        {
            resetLevel();
        }
    }

    private void stopAudioAndThrustEffect()
    {
        audioSource.Stop();
        thrustEffect.Stop();
    }

    private void loadNextLevel()
    {
        state = State.Transcending;
        audioSource.PlayOneShot(levelLoadSound);
        levelLoadEffect.Play();
        StartCoroutine(after(levelLoadDelay, () =>
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }));
    }

    private void resetLevel()
    {
        state = State.Dying;
        audioSource.PlayOneShot(deathSound);
        deathEffect.Play();
        StartCoroutine(after(levelLoadDelay, () =>
        {
            SceneManager.LoadScene(currentSceneIndex);
        }));
    }

    private IEnumerator after(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    private enum State
    {
        Alive, Dying, Transcending
    }
}
