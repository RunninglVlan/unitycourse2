using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

    private static readonly string[] LEVEL1_PASSWORDS = { "bookworm", "archive", "history", "biography", "gallery" };
    private static readonly string[] LEVEL2_PASSWORDS = { "witness", "sheriff", "law", "patrol", "arrest" };
    private static readonly string[] LEVEL3_PASSWORDS = { "apollo", "satellite", "orbit", "space", "galileo" };

    private static readonly Dictionary<string, string[]> LEVEL_PASSWORDS = new Dictionary<string, string[]> {
        { "1", LEVEL1_PASSWORDS }, { "2", LEVEL2_PASSWORDS }, { "3", LEVEL3_PASSWORDS }
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
        if (LEVEL_PASSWORDS.ContainsKey(input))
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
        var levelPasswords = LEVEL_PASSWORDS[level.ToString()];
        levelPassword = levelPasswords[Random.Range(0, levelPasswords.Length)];
        Terminal.ClearScreen();
        Terminal.WriteLine("Please enter your password:");
    }

    private void checkPassword(string input)
    {
        if (levelPassword == input)
        {
            Terminal.WriteLine("Congratulations.");
        }
        else
        {
            Terminal.WriteLine("Invalid password, try again.");
        }
    }

    enum Screen
    {
        MainMenu, Password, Win
    }
}
