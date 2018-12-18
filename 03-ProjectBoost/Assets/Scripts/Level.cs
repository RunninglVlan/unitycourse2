using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private const int LEVEL1_INDEX = 1;

    [SerializeField] float levelLoadDelay = 1;

    private int currentSceneIndex;
    private ProjectBoost projectBoost;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        projectBoost = FindObjectOfType<ProjectBoost>();
    }

    public void restart()
    {
        SceneManager.LoadScene(LEVEL1_INDEX - 1);
    }

    public void loadNext()
    {
        StartCoroutine(after(levelLoadDelay, () =>
        {
            loadNextScene();
        }));
    }

    public void loadNextScene()
    {
        var lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        var nextOrFirstSceneIndex = currentSceneIndex == lastSceneIndex ? 0 : currentSceneIndex + 1;
        SceneManager.LoadScene(nextOrFirstSceneIndex);
    }

    public void reset()
    {
        StartCoroutine(after(levelLoadDelay, () =>
        {
            if (projectBoost.isHardGame)
            {
                SceneManager.LoadScene(LEVEL1_INDEX);
            }
            else
            {
                SceneManager.LoadScene(currentSceneIndex);
            }
        }));
    }

    private IEnumerator after(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }
}
