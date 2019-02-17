using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 colliderSize = Vector3.zero;

    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        collider.size = colliderSize;
    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
