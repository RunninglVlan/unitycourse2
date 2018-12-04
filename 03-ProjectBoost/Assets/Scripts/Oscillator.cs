using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector;
    [Range(0, 1)]
    [SerializeField] float movementFactor;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        var offset = movementFactor * movementVector;
        transform.position = startPosition + offset;
    }
}
