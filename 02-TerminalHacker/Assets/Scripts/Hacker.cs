using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    private static readonly List<string> SUPPORTED_LEVELS = new List<string> { "1", "2", "3" };

    private static readonly string[] LIBRARY_PASSWORDS = { "bookworm", "archive", "history", "biography" };
    private static readonly string[] POLICE_PASSWORDS = { "witness", "sheriff", "law", "patrol", "arrest" };
    private static readonly string[] NASA_PASSWORDS = { "apollo", "satellite", "orbit", "space", "galileo", "lander" };

    private static readonly string[][] LEVEL_PASSWORDS = { LIBRARY_PASSWORDS, POLICE_PASSWORDS, NASA_PASSWORDS };
    private static readonly string[] LEVEL_REWARDS = { "book", "badge", "lab glasses" };
    private static readonly string[] LEVEL_REWARD_ART = {
        @"
    _______
   /      /,
  /      //
 /______//
(______(/",
        @"
   ,   /\   ,
  / '-'  '-' \
  |  POLICE  |
  |   .--.   |
  |  ( 19 )  |
  \   '--'   /
   '--.  .--'
       \/",
        @"
    __         __
   /.-'       `-.\
  //             \\
 /j_______________j\
/o.-==-. .-. .-==-.o\
||      )) ((      ||
 \\____//   \\____//
  `-==-'     `-==-'"
    };

    private int level;
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
        Terminal.WriteLine(
@"What would you like to hack into?

Press 1 for the local library
Press 2 for the police station
Press 3 for NASA

Enter your selection:");
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
        if (SUPPORTED_LEVELS.Contains(input))
        {
            level = int.Parse(input);
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
        var levelPasswords = LEVEL_PASSWORDS[level - 1];
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
        Terminal.WriteLine($"Congratulations, here's your {LEVEL_REWARDS[level - 1]}");
        Terminal.WriteLine(LEVEL_REWARD_ART[level - 1]);
    }

    enum Screen
    {
        MainMenu, Password, Win
    }
}
