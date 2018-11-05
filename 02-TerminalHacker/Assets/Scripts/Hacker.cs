﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Hacker : MonoBehaviour
{

    private static readonly List<Level> LEVELS = new List<Level>
    {
        new Level(
            name: "the local library",
            passwords: new [] { "bookworm", "archive", "history", "biography" },
            reward: @"book
    _______
   /      /,
  /      //
 /______//
(______(/"),
        new Level(
            name: "the police station",
            passwords: new [] { "witness", "sheriff", "law", "patrol", "arrest" },
            reward: @"badge
   ,   /\   ,
  / '-'  '-' \
  |  POLICE  |
  |   .--.   |
  |  ( 19 )  |
  \   '--'   /
   '--.  .--'
       \/"),
        new Level(
            name: "NASA",
            passwords: new []  { "apollo", "satellite", "orbit", "space", "galileo", "lander" },
            reward: @"lab glasses
    __         __
   /.-'       `-.\
  //             \\
 /j_______________j\
/o.-==-. .-. .-==-.o\
||      )) ((      ||
 \\____//   \\____//
  `-==-'     `-==-'")
    };

    private Level level;
    private string levelPassword;
    private Screen screen;

    void Start()
    {
        showMainMenu();
    }

    private void showMainMenu()
    {
        screen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        for (int index = 0; index < LEVELS.Count; index++)
        {
            Terminal.WriteLine($"Press {index + 1} for {LEVELS[index].name}");
        }
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            showMainMenu();
        }
        else if (screen == Screen.MainMenu)
        {
            processMainMenu(input);
        }
        else if (screen == Screen.Password)
        {
            checkPassword(input);
        }
    }

    private void processMainMenu(string input)
    {
        var validLevelNumbers = LEVELS.Select((_, index) => (index + 1).ToString()).ToList();
        if (validLevelNumbers.Contains(input))
        {
            level = LEVELS[int.Parse(input) - 1];
            startLevel();
        }
        else if (input == "mario")
        {
            Terminal.WriteLine("Sorry, but your princess is in another castle.");
        }
        else
        {
            Terminal.WriteLine("Please select a valid level.");
        }
    }

    private void startLevel()
    {
        screen = Screen.Password;
        var levelPasswords = level.passwords;
        levelPassword = levelPasswords[Random.Range(0, levelPasswords.Length)];
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password:");
    }

    private void checkPassword(string input)
    {
        if (levelPassword == input)
        {
            displayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Invalid password, try again.");
        }
    }

    private void displayWinScreen()
    {
        screen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Congratulations, here's your {level.reward}");
    }

    private enum Screen
    {
        MainMenu, Password, Win
    }

    private class Level
    {
        public string name { get; private set; }
        public string[] passwords { get; private set; }
        public string reward { get; private set; }

        public Level(string name, string[] passwords, string reward)
        {
            this.name = name;
            this.passwords = passwords;
            this.reward = reward;
        }
    }
}
