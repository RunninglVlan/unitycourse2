using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProcessing : MonoBehaviour
{
    private ProjectBoost projectBoost;

    void Start()
    {
        projectBoost = FindObjectOfType<ProjectBoost>();
    }

    public void startHardGame()
    {
        projectBoost.startHardGame();
    }

    public void startNormalGame()
    {
        projectBoost.startGame();
    }

    public void restartGame()
    {
        projectBoost.restart();
    }
}
