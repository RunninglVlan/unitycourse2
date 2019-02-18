using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 colliderSize = Vector3.zero;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionDestructionDelay = 1;
    [SerializeField] int pointsPerDeath = 100;

    private ScoreBoard scoreBoard;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        scoreBoard.add(pointsPerDeath);
        var explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, explosionDestructionDelay);
        Destroy(gameObject);
    }
}
