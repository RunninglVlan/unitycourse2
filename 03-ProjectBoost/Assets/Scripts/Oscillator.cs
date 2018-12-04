using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(7, 0, 0);
    [SerializeField] float cycleTime = 2;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        var cycles = Time.time / Mathf.Max(cycleTime, 0.1f);
        const float tau = Mathf.PI * 2;
        var sin = Mathf.Sin(cycles * tau);
        var movementFactor = sin / 2 + 0.5f;
        var offset = movementFactor * movementVector;
        transform.position = startPosition + offset;
    }
}
