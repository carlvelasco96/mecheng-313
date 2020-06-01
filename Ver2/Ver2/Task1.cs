using System;
using System.Runtime.Serialization;

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
    public int state = S0;

    public struct cell_FST //groups variables of a cell (indexOfNextState and 2 actions)
    {
        public int nextState;
        public string action;
        public string action2;
        public string action3;
        public cell_FST(int state, string act1)
        {
            nextState = state;
            action = act1;
            action2 = "NoAction";
            action3 = "NoAction";
        }
        public cell_FST(int state, string act1, string act2)
        {
            nextState = state;
            action = act1;
            action2 = act2;
            action2 = act2;
            action3 = "NoAction";
        }
        public cell_FST(int state, string act1, string act2, string act3)
        {
            nextState = state;
            action = act1;
            action2 = act2;
            action3 = act3;
        }
    }

    static cell_FST[,] FST_X = {
    // S0                           S1                              S2
    { new cell_FST(S1, "NoAction", "NoAction", "NoAction"), new cell_FST(S0, "NoAction", "NoAction", "NoAction"), new cell_FST(S0, "NoAction", "NoAction", "NoAction") },     //E0
    { new cell_FST(S0, "NoAction", "NoAction", "NoAction"), new cell_FST(S2, "NoAction", "NoAction", "NoAction"), new cell_FST(S2, "NoAction", "NoAction", "NoAction") },     //E1
    { new cell_FST(S2, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction", "NoAction") },     //E2
    };


    //set indexOfNextState of cell
    public void SetNextState(int S, int E, int newIndexOfNextState)
    {
        FST_X[S, E].nextState = newIndexOfNextState;
    }

    //set action of cell
    public void SetActions(int S, int E, string newAction)
    {
        FST_X[S, E].action = newAction;
    }

    //set action of cell
    public void SetActions(int S, int E, string newAction, string newAction2)
    {
        FST_X[S, E].action = newAction;
        FST_X[S, E].action2 = newAction2;
    }

    //set action of cell
    public void SetActions(int S, int E, string newAction, string newAction2, string newAction3)
    {
        FST_X[S, E].action = newAction;
        FST_X[S, E].action2 = newAction2;
        FST_X[S, E].action3 = newAction3;
    }

    //return indexOfNextState of cell
    public int GetNextState(int E, int S)
    {
        return FST_X[S, E].nextState;
    }

    //return action of cell
    public string GetActions(int E, int S, int actionNumber)
    {
        if (actionNumber == 2)
        {
            return FST_X[S, E].action2;
        }
        else if (actionNumber == 3)
        {
            return FST_X[S, E].action3;
        }
        else
        {
            return FST_X[S, E].action;
        }
    }

    static void Main()
    {
        //Finite State Machine Function goes here
    }
}
