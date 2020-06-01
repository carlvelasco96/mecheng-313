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
    // S0                           			S1                          				S2
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
    public void SetActions(int S, int E, string newAction)
    {
        FST_X[S, E].action = newAction;
    }

    //return indexOfNextState of cell
    public int GetNextState(int E, int S)
    {
        return FST_X[S, E].nextState;
    }

    //return action of cell
    public string GetActions(int E, int S)
    {
        return FST_X[S, E].action;
    }
	
    static void Main()
    {
       //Finite State Machine Function goes here
    }
}