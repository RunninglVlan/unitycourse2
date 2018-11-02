using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    private static readonly List<string> SUPPORTED_LEVELS = new List<string> { "1", "2", "3" };

    private int level;
    private Screen screen = Screen.MainMenu;

    void Start()
    {
        showMainMenu();
    }

    private void showMainMenu()
    {
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
        Terminal.WriteLine($"You've chosen the level {level}.");
        Terminal.WriteLine("Please enter your password:");
    }

    enum Screen
    {
        MainMenu, Password, Win
    }
}
