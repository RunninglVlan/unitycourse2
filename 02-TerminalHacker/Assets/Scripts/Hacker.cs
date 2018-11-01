using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    private static readonly List<string> SUPPORTED_LEVELS = new List<string> { "1", "2", "3" };

    private int level;

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
        else if (input == "mario")
        {
            Terminal.WriteLine("Sorry, but your princess is in another castle.");
        }
        else if (SUPPORTED_LEVELS.Contains(input))
        {
            level = int.Parse(input);
            startLevel();
        }
        else
        {
            Terminal.WriteLine("Please select valid level.");
        }
    }

    private void startLevel()
    {
        Terminal.WriteLine($"You've chosen level {level}.");
    }
}
