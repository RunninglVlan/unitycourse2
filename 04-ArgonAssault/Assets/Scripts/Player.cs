using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Camera resolutionCamera;
    [SerializeField] int movementSpeed = 10;
    [SerializeField] Vector2 extents = Vector2.one;

    private float xBoundary;
    private float yBoundary;
    private Vector2 resolution;

    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
        setUpMovementBoundaries();
    }

    private void setUpMovementBoundaries()
    {
        var zeroBoundary = resolutionCamera.ViewportToWorldPoint(new Vector3(0, 0, transform.localPosition.z));
        var oneBoundary = resolutionCamera.ViewportToWorldPoint(new Vector3(1, 1, transform.localPosition.z));
        xBoundary = (oneBoundary.x - zeroBoundary.x) / 2 - extents.x;
        yBoundary = (oneBoundary.y - zeroBoundary.y) / 2 - extents.y;
    }

    void Update()
    {
        processResolutionChange();
        move();
    }

    private void processResolutionChange()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            resolution = new Vector2(Screen.width, Screen.height);
            setUpMovementBoundaries();
        }
    }

    private void move()
    {
        var delta = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        delta.Normalize();
        delta *= movementSpeed * Time.deltaTime;
        var newPosition = transform.localPosition + delta;
        newPosition.x = Mathf.Clamp(newPosition.x, -xBoundary, xBoundary);
        newPosition.y = Mathf.Clamp(newPosition.y, -yBoundary, yBoundary);
        transform.localPosition = newPosition;
    }
}
