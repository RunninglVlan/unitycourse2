using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOscillator : Oscillator
{
    [SerializeField] float fovAmplitude = 20;

    private new Camera camera;
    private float startFov;

    void Start()
    {
        camera = GetComponent<Camera>();
        startFov = camera.fieldOfView;
    }

    void Update()
    {
        var sin = oscillate();
        var offset = sin * fovAmplitude;
        camera.fieldOfView = startFov + offset;
    }
}
