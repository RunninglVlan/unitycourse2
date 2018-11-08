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
    [SerializeField] GameObject launchPad;
    [SerializeField] float levelLoadDelay = 1;

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
            audioSource.Stop();
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
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
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
        if (other.gameObject.tag == "Finish")
        {
            state = State.Transcending;
            StartCoroutine(after(levelLoadDelay, loadNextLevel));
        }
        else if (other.gameObject.tag != "Friendly")
        {
            state = State.Dying;
            StartCoroutine(after(levelLoadDelay, resetLevel));
        }
    }

    private IEnumerator after(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    private void resetLevel()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void loadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    private enum State
    {
        Alive, Dying, Transcending
    }
}
