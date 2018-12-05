using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    private const string THRUST_BUTTON = "Jump";
    private const string ROTATION_AXIS = "Horizontal";
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
    private bool transitioning = false;
    private bool collisionsDisabled = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
            loadNextDebugLevel();
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
        StartCoroutine(after(levelLoadDelay, () =>
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }));
    }

    private void loadNextDebugLevel()
    {
        var lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        var nextOrFirstSceneIndex = currentSceneIndex == lastSceneIndex ? 0 : currentSceneIndex + 1;
        SceneManager.LoadScene(nextOrFirstSceneIndex);
    }

    private void resetLevel()
    {
        transitioning = true;
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
}
