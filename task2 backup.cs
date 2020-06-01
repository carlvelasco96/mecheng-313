using System;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;

class FiniteStateTable
{
    //define the indexes of the states and the events
    public const int S0 = 0;
    public const int S1 = 1;
    public const int S2 = 2;
    public const int E0 = 0;
    public const int E1 = 1;
    public const int E2 = 2;

    //initialise initial state
    static int state = S0;

    //initialise log
    static List<string> actionLog = new List<string>();

    public struct cell_FST //groups variables of a cell (indexOfNextState and 2 actions)
    {
        public int nextState;
        public string action1;
        public string action2;
        public cell_FST(int state, string act1, string act2)
        {
            nextState = state;
            action1 = act1;
            action2 = act2;
        }
    }

    static cell_FST[,] FST_X = {
    // S0                           S1                          S2
    { new cell_FST(S1, "ActionX", "ActionY"), new cell_FST(S0, "ActionW", "NoAction"), new cell_FST(S0, "ActionW", "NoAction") },     //E0
    { new cell_FST(S0, "NoAction", "NoAction"), new cell_FST(S2, "ActionX", "ActionZ"), new cell_FST(S2, "NoAction", "NoAction") },     //E1
    { new cell_FST(S2, "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction"), new cell_FST(S1, "ActionX", "ActionY") },     //E2
    };


    //set indexOfNextState of cell
    public void SetNextState(int S, int E, int newIndexOfNextState)
    {
        FST_X[S, E].nextState = newIndexOfNextState;
    }

    //set action of cell
    public void SetActions(int S, int E, int actionIndex, string newAction) //originally  public void SetActions(int S, int E, string newAction)
    {
        //FST_X[S, E].action = newAction;
        if (actionIndex == 1)
        {
            FST_X[S, E].action1 = newAction;
        }
        if (actionIndex == 2)
        {
            FST_X[S, E].action2 = newAction;
        }
        
    }

    //return indexOfNextState of cell
    public int GetNextState(int E, int S)
    {
        return FST_X[S, E].nextState;
    }

    //return action of cell
    public string GetActions(int E, int S)
    {
        //return FST_X[S, E].action;
        return FST_X[S, E].action1 + "and" + FST_X[S, E].action2;
    }

    static private void ActionW()
    {
        Console.WriteLine("Action W");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionW Executed");
    }

    static private void ActionX()
    {
        Console.WriteLine("Action X");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionX Executed");
    }

    static private void ActionY()
    {
        Console.WriteLine("Action Y");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionY Executed");
    }

    static private void ActionZ()
    {
        Console.WriteLine("Action Z");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionZ Executed");
    }

    static private void ActionJ()
    {
        Console.WriteLine("Action J");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionJ Executed");
    }

    static private void ActionK()
    {
        Console.WriteLine("Action K");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionK Executed");
    }

    static private void ActionL()
    {
        Console.WriteLine("Action L");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionL Executed");
    }

    static private void NoAction()
    {
        //do nothing
    }

    private static void new_state(int newState)
    {
        state = newState;
        Console.WriteLine("Now in State " + state);
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " Entered State " + state);
    }

    private static void execute(string action)
    {
        if (action == "NoAction") { NoAction(); }
        if (action == "ActionW") { ActionW(); }
        if (action == "ActionX") { ActionX(); }
        if (action == "ActionY") { ActionY(); }
        if (action == "ActionZ") { ActionZ(); }
        if (action == "ActionJ") { ActionJ(); }
        if (action == "ActionK") { ActionK(); }
        if (action == "ActionL") { ActionL(); }
    }

    private static void quit(string filePath)
    {
        string log = "";
        for (int i = 0; i < actionLog.Count; i++)
        {
            log += actionLog[i] + "\n";
        }
        System.IO.File.WriteAllText(@filePath, log);
        System.Environment.Exit(0);
    }

    static void Main()
    {
        char keyEntered = '0';
        int keyEvent;

        while (true)
        {
            keyEntered = (char)Console.Read();
            keyEvent = -1;
            if (keyEntered == ('a')) keyEvent = E0;
            if (keyEntered == ('b')) keyEvent = E1;
            if (keyEntered == ('c')) keyEvent = E2;
            if (keyEntered == ('q')) keyEvent = 4;
            if (keyEvent >= 0)
            {
                string time = System.DateTime.Now.ToString();
                actionLog.Add(time + " User Entered: " + keyEntered);

                if ((keyEntered == 'a') || (keyEntered == 'b') || (keyEntered == 'c'))
                {
                    execute(FST_X[keyEvent, state].action1);
                    execute(FST_X[keyEvent, state].action2);

                    if (state != FST_X[keyEvent, state].nextState)
                    {
                        new_state(FST_X[keyEvent, state].nextState);
                    }
                   
                } else if (keyEntered == 'q')
                {
                    Console.WriteLine("Please enter the file path of the file where you wish to have activity logged");
                    string filePath = "";
                    while (filePath == "")
                    {
                        filePath = Console.ReadLine();
                    }
                    try
                    {
                        quit(filePath);
                    }
                    catch
                    {
                        Console.WriteLine("File path not recognised, please try again");
                    }
                }
                else
                {
                    Console.WriteLine("Command not recognised. Please try again.");
                }
            }
        }
    }
}