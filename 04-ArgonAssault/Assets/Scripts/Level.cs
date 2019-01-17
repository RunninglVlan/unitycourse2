using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1;

    private int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        loadNext();
    }

    private void loadNext()
    {
        StartCoroutine(after(levelLoadDelay, () =>
        {
            loadNextScene();
        }));
    }

    private IEnumerator after(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    private void loadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
