using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1;
    [SerializeField] GameObject explosion;

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnTriggerEnter(Collider other)
    {
        SendMessage("OnPlayerDeath");
        explode();
        resetLevel();
    }

    private void explode()
    {
        explosion.SetActive(true);
    }


    private void resetLevel()
    {
        StartCoroutine(after(levelLoadDelay, () =>
        {
            SceneManager.LoadScene(currentSceneIndex);
        }));
    }

    private IEnumerator after(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
