using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{

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
        else
        {
            Terminal.WriteLine("Please select correct option.");
        }
    }
}
