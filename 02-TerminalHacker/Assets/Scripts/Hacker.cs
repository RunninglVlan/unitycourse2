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
        Terminal.WriteLine(
@"What would you like to hack into?

Press 1 for the local library
Press 2 for the police station
Press 3 for NASA

Enter your selection:");
    }
}
