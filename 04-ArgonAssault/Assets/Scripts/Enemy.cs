using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 colliderSize = Vector3.zero;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionDestructionDelay = 1;

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
        var explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, explosionDestructionDelay);
        Destroy(gameObject);
    }
}
