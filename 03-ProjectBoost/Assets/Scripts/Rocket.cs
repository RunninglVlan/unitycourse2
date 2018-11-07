using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private const string THRUST_BUTTON = "Jump";
    private const float DISTANCE_FROM_PAD = 2.5f;

    [SerializeField] int thrust = 20;
    [SerializeField] int torque = 10;
    [SerializeField] GameObject launchPad;

    new private Rigidbody rigidbody;
    private AudioSource audioSource;
    private Vector3 startingPosition;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        startingPosition = launchPad.transform.position + new Vector3(0, DISTANCE_FROM_PAD, 0);
        reset();
    }

    private void reset()
    {
        transform.position = startingPosition;
        transform.rotation = Quaternion.identity;
        rigidbody.velocity = Vector3.zero;
    }

    void Update()
    {
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
        if (other.gameObject.tag != "Friendly")
        {
            reset();
        }
    }
}
