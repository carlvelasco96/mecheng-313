// Task No.:    3
// Author:      Charlene Lo     - clo261    - 465948311
//              Carl Velasco    - cvel317   - 6693979
// Group No.:   29
// Description: This class implements the creation of the Finite State Machine
//              (FSM) detailed in task 3 of the assignment. It herits the states
//              and actions in task 2.

using System;
using System.Threading;

class Task3 : Task2 // Inherits Task 2
{
    // States of the FSM of Task 3
    private const int SA = 0;
    private const int SB = 3;

    /* ---------------------------------------------------------------------------------------------------------------------
    MAIN
    --------------------------------------------------------------------------------------------------------------------- */

    private static void Main()
    {
        // INITIALISE Multi Threading
        Thread th = Thread.CurrentThread;
        th.Name = "MainThread";

        // CREATE FST
        // Task 2 FSM
        FiniteStateTable FST_X = new FiniteStateTable();
        //define FST_X
        FST_X.SetNextState(S0, E0, S1);
        FST_X.SetActions(S0, E0, "ActionX", "ActionY");
        FST_X.SetNextState(S1, E0, S0);
        FST_X.SetActions(S1, E0, "ActionW");
        FST_X.SetNextState(S2, E0, S0);
        FST_X.SetActions(S2, E0, "ActionW");
        FST_X.SetNextState(S1, E1, S2);
        FST_X.SetActions(S1, E1, "ActionX", "ActionZ");
        FST_X.SetNextState(S2, E2, S1);
        FST_X.SetActions(S2, E2, "ActionX", "ActionY");
        // Task 3 FSM
        FiniteStateTable FST_Y = new FiniteStateTable(S0 + SB);
        //define FST_Y
        FST_Y.SetNextState(0, E0, SB);
        FST_Y.SetNextState(1, E0, SB);
        FST_Y.SetNextState(2, E0, SB);
        FST_Y.SetNextState(4, E0, SA);
        FST_Y.SetActions(4, E0, "ActionJ", "ActionK", "ActionL");
        FST_Y.SetNextState(4, E1, SA);
        FST_Y.SetActions(4, E1, "ActionJ", "ActionK", "ActionL");
        FST_Y.SetNextState(4, E2, SA);
        FST_Y.SetActions(4, E2, "ActionJ", "ActionK", "ActionL");

        // DECLARE AND INITIALISE VARIABLES
        char keyEntered = '0';
        int keyEvent;
        int colX;
        int rowX;
        int colY;
        int rowY;

        // RUN THE APPLICATION
        while (true)
        {
            // Receive Key Press
            keyEntered = (char)Console.Read();
            // Set Event Value
            keyEvent = -1;
            if (keyEntered == ('a')) keyEvent = E0;
            if (keyEntered == ('b')) keyEvent = E1;
            if (keyEntered == ('c')) keyEvent = E2;
            if (keyEntered == ('q')) keyEvent = 4;
            // If Event Driven Key Press
            if (keyEvent >= 0)
            {
                // Set Row and Column Values;
                // X FSM
                rowX = keyEvent;
                colX = FST_X.state;
                // Y FSM
                rowY = keyEvent;
                colY = FST_X.state + FST_Y.state;
                if (keyEntered != 'q')
                {
                    // Execute the Actions
                    // X FSM
                    execute(FST_X.GetActions(colX, rowX));
                    // Y FSM
                    execute(FST_Y.GetActions(colY, rowY));
                    // Evaluate if there is a change of state
                    // X FSM
                    if (FST_X.state != FST_X.GetNextState(colX, rowX))
                    {
                        FST_X.state = FST_X.GetNextState(colX, rowX);
                        string message = "";
                        if (FST_X.state == 0) message = "S0";
                        if (FST_X.state == 1) message = "S1";
                        if (FST_X.state == 2) message = "S2";
                        Console.WriteLine("Now in State " + message);
                    }
                    // Y FSM
                    if ((FST_Y.GetNextState(colY, rowY) > 2 && FST_Y.state <= 2) ||
                        (FST_Y.GetNextState(colY, rowY) < 3 && FST_Y.state >= 3))
                    {
                        FST_Y.state = FST_Y.GetNextState(colY, rowY);
                        string message = "";
                        if (FST_Y.state == 0) message = "SA";
                        if (FST_Y.state == 3) message = "SB";
                        Console.WriteLine("Now in State " + message);
                    }
                }
                else
                {
                    // Create the File to Log File for Time Stamping User Activity
                    // Acquire File Path
                    Console.WriteLine("Please enter the file path of the file where you wish to have activity logged");
                    string filePath = "";
                    while (filePath == "")
                    {
                        filePath = Console.ReadLine();
                    }
                    try // Save File
                    {
                        quit(filePath);
                    }
                    catch // Invalid File Path
                    {
                        Console.WriteLine("File path not recognised, please try again");
                    }
                }
            }
        }
    }
}