using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private const string THRUST_BUTTON = "Jump";

    [SerializeField] int thrust = 20;
    [SerializeField] int torque = 10;

    new private Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        if (Input.GetButton(THRUST_BUTTON))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrust);
        }
        rigidbody.AddTorque(Vector3.back * torque * Input.GetAxis("Horizontal"));
    }
}
