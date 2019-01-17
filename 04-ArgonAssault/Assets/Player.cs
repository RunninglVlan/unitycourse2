using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int movementSpeed = 10;

    void Update()
    {
        move();
    }

    private void move()
    {
        var delta = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        delta.Normalize();
        delta *= movementSpeed * Time.deltaTime;
        var newPosition = transform.localPosition + delta;
        transform.localPosition = newPosition;
    }
}
