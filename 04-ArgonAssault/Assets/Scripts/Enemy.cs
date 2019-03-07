using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Vector3 colliderSize = Vector3.zero;

    [Header("Hit")]
    [SerializeField] AudioClip hitSound;
    [SerializeField] float hitVolume = 0.5f;

    [Header("Explosion")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionDestructionDelay = 1;

    [Header("Damage")]
    [SerializeField] int pointsPerHit = 100;
    [SerializeField] int hitsUntilDeath = 3;

    private ScoreBoard scoreBoard;
    private AudioSource hitAudio;

    void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        AddBoxCollider();
        AddAudioSource();
    }

    private void AddBoxCollider()
    {
        var collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
        collider.size = colliderSize;
    }

    private void AddAudioSource()
    {
        hitAudio = gameObject.AddComponent<AudioSource>();
        hitAudio.clip = hitSound;
        hitAudio.volume = hitVolume;
        hitAudio.playOnAwake = false;
    }

    void OnParticleCollision(GameObject other)
    {
        hit();
        if (hitsUntilDeath <= 0)
        {
            die();
        }
        else
        {
            hitAudio.Play();
        }
    }

    private void hit()
    {
        scoreBoard.add(pointsPerHit);
        hitsUntilDeath--;
    }

    private void die()
    {
        var explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, explosionDestructionDelay);
        Destroy(gameObject);
    }
}
