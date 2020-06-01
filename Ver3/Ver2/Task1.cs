using System;
using System.Runtime.Serialization;

class FiniteStateTable
{
    //define the indexes of the states and the events
    public const int S0 = 0;
    public const int S1 = 1;
    public const int S2 = 2;
    public const int S3 = 3;
    public const int S4 = 4;
    public const int S5 = 5;
    public const int E0 = 0;
    public const int E1 = 1;
    public const int E2 = 2;

    //initialise initial state
    public int state = S0;

    /// <summary>
    /// groups variables of a cell (indexOfNextState and 3 actions)
    /// contains two overflow constructors for cases with more actions
    /// </summary>
    public struct cell_FST 
    {
        //variables
        public int nextState;
        public string action;
        public string action2;
        public string action3;
        public cell_FST(int state, string act1)
        {
            //if only one action to be executed
            nextState = state;
            action = act1;
            action2 = "NoAction";
            action3 = "NoAction";
        }
        public cell_FST(int state, string act1, string act2) //overflow 1
        {
            //if two actions to be executed
            nextState = state;
            action = act1;
            action2 = act2;
            action3 = "NoAction";
        }
        public cell_FST(int state, string act1, string act2, string act3) //overflow 2
        {
            //if three actions to be executed
            nextState = state;
            action = act1;
            action2 = act2;
            action3 = act3;
        }
    }
 
    /// <summary>
    /// basic finite state machine with no function
    /// 3x6 to accommodate task 3
    /// 3x3 tables only use left half of table. 
    /// </summary>
    cell_FST[,] FST = {
    { new cell_FST(S0, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction", "NoAction"), new cell_FST(S2, "NoAction", "NoAction", "NoAction"), // E0
      new cell_FST(S3, "NoAction", "NoAction", "NoAction"), new cell_FST(S4, "NoAction", "NoAction", "NoAction"), new cell_FST(S5, "NoAction", "NoAction", "NoAction") },  // E0
    { new cell_FST(S0, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction", "NoAction"), new cell_FST(S2, "NoAction", "NoAction", "NoAction"), // E1
      new cell_FST(S3, "NoAction", "NoAction", "NoAction"), new cell_FST(S4, "NoAction", "NoAction", "NoAction"), new cell_FST(S5, "NoAction", "NoAction", "NoAction") },  // E1
    { new cell_FST(S0, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction", "NoAction"), new cell_FST(S2, "NoAction", "NoAction", "NoAction"), // E2
      new cell_FST(S3, "NoAction", "NoAction", "NoAction"), new cell_FST(S4, "NoAction", "NoAction", "NoAction"), new cell_FST(S5, "NoAction", "NoAction", "NoAction") },  // E2
    };

    /// <summary>
    /// set nextState of cell
    /// </summary>
    /// <param name="S">state that the FSM is currently in (column of FSM)</param>
    /// <param name="E">the event triggered (row of FSM)</param>
    /// <param name="newIndexOfNextState">the next state of the FSM in this event</param>
    public void SetNextState(int S, int E, int newIndexOfNextState)
    {
        FST[E, S].nextState = newIndexOfNextState;
    }

    /// <summary>
    /// sets the actions of the cell, in the event of there being only one action
    /// </summary>
    /// <param name="S">state that the FSM is currently in (column of FSM)</param>
    /// <param name="E">the event triggered (row of FSM)</param>
    /// <param name="newAction">the action that occurs in this event</param>
    public void SetActions(int S, int E, string newAction)
    {
        FST[E, S].action = newAction;
        FST[E, S].action2 = "NoAction";
        FST[E, S].action3 = "NoAction";
    }

    /// <summary>
    /// overflow constructor
    /// sets the actions of the cell, in the event of there being two actions
    /// </summary>
    /// <param name="S">state that the FSM is currently in (column of FSM)</param>
    /// <param name="E">the event triggered (row of FSM)</param>
    /// <param name="newAction">the action that occurs in this event</param>
    /// <param name="newAction2">the second action that occurs in this event</param>
    public void SetActions(int S, int E, string newAction, string newAction2)
    {
        FST[E, S].action = newAction;
        FST[E, S].action2 = newAction2;
        FST[E, S].action3 = "NoAction";
    }

    /// <summary>
    /// overflow constructor
    /// sets the actions of the cell, in the event of there being three actions
    /// </summary>
    /// <param name="S">state that the FSM is currently in (column of FSM)</param>
    /// <param name="E">the event triggered (row of FSM)</param>
    /// <param name="newAction">the action that occurs in this event</param>
    /// <param name="newAction2">the second action that occurs in this event</param>
    /// <param name="newAction3">the third action that ocurs in this event</param>
    public void SetActions(int S, int E, string newAction, string newAction2, string newAction3)
    {
        FST[E, S].action = newAction;
        FST[E, S].action2 = newAction2;
        FST[E, S].action3 = newAction3;
    }

    /// <summary>
    /// returns the next state in the case the event specified occurs
    /// </summary>
    /// <param name="S">state that the FSM is currently in (column of FSM)</param>
    /// <param name="E">the event triggered (row of FSM)</param>
    /// <returns>nextState of specified cell</returns>
    public int GetNextState(int S, int E)
    {
        return FST[E, S].nextState;
    }

    /// <summary>
    /// returns the actions in the case the event specified occurs
    /// </summary>
    /// <param name="S">state that the FSM is currently in (column of FSM)</param>
    /// <param name="E">the event triggered (row of FSM)</param>
    /// <returns>string of actions separated by commas</returns>
    public string GetActions(int S, int E)
    {
        return FST[E, S].action + "," + FST[E, S].action2 + "," + FST[E, S].action3;
    }

    static void Main()
    {
        //Finite State Machine Function goes here
        //This is merely a class definition so there is none
    }
}
