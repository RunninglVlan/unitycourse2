using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ProjectBoost : Singleton
{
    private bool hardDifficulty;
    private bool gameStarted;
    private float gameTime;
    private List<Score> scores = new List<Score>();

    public void Start()
    {
        hardDifficulty = false;
        gameStarted = false;
        gameTime = 0;
    }

    public void restart()
    {
        Start();
        FindObjectOfType<Level>().restart();
    }

    public void startHardGame()
    {
        hardDifficulty = true;
        startGame();
    }

    public void startGame()
    {
        gameStarted = true;
        FindObjectOfType<Level>().loadNext();
    }

    public bool isHardGame => hardDifficulty;

    public void stopGame()
    {
        gameStarted = false;
        scores.Add(new Score(gameTime, hardDifficulty));
    }

    public string leaderboard => scores
            .OrderBy(score => score.time)
            .Select(score => score.ToString())
            .Aggregate((a, b) => a + Environment.NewLine + b);

    void Update()
    {
        if (!gameStarted)
        {
            return;
        }
        gameTime += Time.deltaTime;
    }

    private class Score
    {
        public float time { get; private set; }
        private bool hardDifficulty;
        private DateTime date;
        string difficulty => hardDifficulty ? "Hard" : "Normal";

        public Score(float time, bool hardDifficulty)
        {
            this.time = time;
            this.hardDifficulty = hardDifficulty;
            date = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{time} - {difficulty} - {date.ToShortDateString()} {date.ToShortTimeString()}";
        }
    }
}
