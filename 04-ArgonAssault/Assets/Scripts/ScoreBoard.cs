using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    private Text textComponent;
    private int score = 0;

    void Start()
    {
        textComponent = GetComponent<Text>();
        show();
    }

    public void add(int points)
    {
        this.score += points;
        show();
    }

    private void show()
    {
        textComponent.text = this.score.ToString();
    }
}
