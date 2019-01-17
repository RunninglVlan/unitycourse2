using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Oscillator : MonoBehaviour
{
    [SerializeField] float cycleTime = 2;

    protected float oscillate()
    {
        var cycles = Time.time / Mathf.Max(cycleTime, 0.1f);
        const float tau = Mathf.PI * 2;
        return Mathf.Sin(cycles * tau);
    }
}
