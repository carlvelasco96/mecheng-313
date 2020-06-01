using System;
using System.Resources;
using System.Runtime.CompilerServices;

class FiniteStateTable
{
    public const int S0 = 0;
    public const int S1 = 1;
    public const int S2 = 2;
    public const int E0 = 0;
    public const int E1 = 1;
    public const int E2 = 2;


    static int state = S0;

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
    public void SetNextState(int state, int eventIndex, int newIndexOfNextState)
    {
        //TODO
    }

    //set action of cell
    public void SetActions(int state, int eventIndex, string newAction)
    {
        //TODO
    }

    //return indexOfNextState of cell
    public int GetNextState(int stateIndex)
    {
        return FST_X[state, 2].nextState;
    }

    ////return action of cell
    //public string GetActions(int stateIndex)
    //{
    //    //TODO
    //}

    static private void ActionW()
    {
        Console.WriteLine("Action W");
    }

    static private void ActionX()
    {
        Console.WriteLine("Action X");
    }

    static private void ActionY()
    {
        Console.WriteLine("Action Y");
    }

    static private void ActionZ()
    {
        Console.WriteLine("Action Z");
    }

    static private void ActionJ()
    {
        Console.WriteLine("Action J");
    }

    static private void ActionK()
    {
        Console.WriteLine("Action K");
    }

    static private void ActionL()
    {
        Console.WriteLine("Action L");
    }

    static private void NoAction()
    {
        //do nothing
    }

    private static void new_state(int newState)
    {
        state = newState;
        Console.WriteLine("Now in State " + state);
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
            if (keyEvent >= 0)
            {
                execute(FST_X[keyEvent, state].action1);
                execute(FST_X[keyEvent, state].action2);

                if (state != FST_X[keyEvent, state].nextState)
                {
                    new_state(FST_X[keyEvent, state].nextState);
                }
            }
        }
    }
}