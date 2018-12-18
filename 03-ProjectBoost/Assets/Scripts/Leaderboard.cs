using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    private Text textComponent;
    private ProjectBoost projectBoost;

    void Start()
    {
        textComponent = GetComponent<Text>();
        projectBoost = FindObjectOfType<ProjectBoost>();
        projectBoost.stopGame();
        textComponent.text = projectBoost.leaderboard;
    }
}
