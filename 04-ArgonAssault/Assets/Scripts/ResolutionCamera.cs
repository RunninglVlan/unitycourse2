using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionCamera : MonoBehaviour
{
    private new Camera camera;
    private Vector2 resolution = Vector2.zero;
    private PlayerController player;

    void Awake()
    {
        camera = GetComponent<Camera>();
        camera.fieldOfView = Camera.main.fieldOfView;
    }

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        processResolutionChange();
    }

    private void processResolutionChange()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            var playerPositionZ = player.gameObject.transform.localPosition.z;
            var zeroBoundary = camera.ViewportToWorldPoint(new Vector3(0, 0, playerPositionZ));
            var oneBoundary = camera.ViewportToWorldPoint(new Vector3(1, 1, playerPositionZ));
            player.setUpMovementBoundaries(zeroBoundary, oneBoundary);

            resolution = new Vector2(Screen.width, Screen.height);
        }
    }
}
