using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int movementSpeed = 20;

    [Header("Rotation")]
    [SerializeField] float positionPitchFactor = -2;
    [SerializeField] float throwPitchFactor = -20;
    [SerializeField] float positionYawFactor = 2;
    [SerializeField] float throwRollFactor = -20;

    private float xBoundary;
    private float yBoundary;
    private Vector3 controlThrow;
    private bool controlsFrozen;

    public void setUpMovementBoundaries(Vector3 zeroBoundary, Vector3 oneBoundary)
    {
        var extents = GetComponent<Renderer>().bounds.extents;
        xBoundary = (oneBoundary.x - zeroBoundary.x) / 2 - extents.x;
        yBoundary = (oneBoundary.y - zeroBoundary.y) / 2 - extents.y;
    }

    void Update()
    {
        if (controlsFrozen)
        {
            return;
        }
        move();
        rotate();
    }

    private void move()
    {
        controlThrow = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var nomalizedThrow = controlThrow;
        nomalizedThrow.Normalize();
        var offset = nomalizedThrow * movementSpeed * Time.deltaTime;
        var newPosition = transform.localPosition + offset;
        newPosition.x = Mathf.Clamp(newPosition.x, -xBoundary, xBoundary);
        newPosition.y = Mathf.Clamp(newPosition.y, -yBoundary, yBoundary);
        transform.localPosition = newPosition;
    }

    private void rotate()
    {
        var pitch = transform.localPosition.y * positionPitchFactor;
        pitch += controlThrow.y * throwPitchFactor;
        var yaw = transform.localPosition.x * positionYawFactor;
        var roll = controlThrow.x * throwRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void OnPlayerDeath()
    {
        freezeControls();
    }

    private void freezeControls()
    {
        controlsFrozen = true;
    }
}
