using System;
using System.Resources;
using System.Runtime.CompilerServices;

class FiniteStateTable
{
  public const int S0 = 0;
  public const int S1 = 1;
  public const int S2 = 2;
  public const int SA = 0;
  public const int SB = 2;
  public const int E0 = 0;
  public const int E1 = 1;
  public const int E2 = 2;


  static int stateX = S0;
  static int stateY = SB;

  public struct cell_FST //groups variables of a cell (indexOfNextState and 2 actions)
  {
    public int nextState;
    public string action1;
    public string action2;
    public string action3;
    public cell_FST(int state, string act1, string act2, string act3)
    {
      nextState = state;
      action1 = act1;
      action2 = act2;
      action3 = act3;
    }
  }

  /* ---------------------------------------------------------------------------------------------------------------------
  FINITE STATE TABLES
  --------------------------------------------------------------------------------------------------------------------- */
  static cell_FST[,] FST_X = {
  //                  S0                                        S1                                       S2
    { new cell_FST(S1, "ActionX", "ActionY", "NoAction"),   new cell_FST(S0, "ActionW", "NoAction", "NoAction"),  new cell_FST(S0, "ActionW", "NoAction", "NoAction") },  // E0
    { new cell_FST(S0, "NoAction", "NoAction", "NoAction"), new cell_FST(S2, "ActionX", "ActionZ", "NoAction"),   new cell_FST(S2, "NoAction", "NoAction", "NoAction") }, // E1
    { new cell_FST(S2, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "NoAction", "NoAction", "NoAction"), new cell_FST(S1, "ActionX", "ActionY", "NoAction") },   // E2
  };

  static cell_FST[,] FST_Y = {
    { new cell_FST(SB, "NoAction", "NoAction", "NoAction"), new cell_FST(SB, "NoAction", "NoAction", "NoAction"), new cell_FST(SB, "NoAction", "NoAction", "NoAction"), // E0
      new cell_FST(SA, "ActionJ", "ActionK", "ActionL"), new cell_FST(SB, "NoAction", "NoAction", "NoAction"), new cell_FST(SB, "NoAction", "NoAction", "NoAction") },  // E0
    { new cell_FST(SA, "NoAction", "NoAction", "NoAction"), new cell_FST(SA, "NoAction", "NoAction", "NoAction"), new cell_FST(SA, "NoAction", "NoAction", "NoAction"), // E1
      new cell_FST(SA, "ActionJ", "ActionK", "ActionL"), new cell_FST(SB, "NoAction", "NoAction", "NoAction"), new cell_FST(SB, "NoAction", "NoAction", "NoAction") },  // E1
    { new cell_FST(SA, "NoAction", "NoAction", "NoAction"), new cell_FST(SA, "NoAction", "NoAction", "NoAction"), new cell_FST(SA, "NoAction", "NoAction", "NoAction"), // E2
      new cell_FST(SA, "ActionJ", "ActionK", "ActionL"), new cell_FST(SB, "NoAction", "NoAction", "NoAction"), new cell_FST(SB, "NoAction", "NoAction", "NoAction") },  // E2
  };

  /* ---------------------------------------------------------------------------------------------------------------------
  FUNCTIONS
  --------------------------------------------------------------------------------------------------------------------- */

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
    return FST_X[stateX, 2].nextState;
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

  private static void new_stateX(int newState)
  {
    stateX = newState;
    string message = "";
    if (stateX == 0) message = "S0";
    if (stateX == 1) message = "S1";
    if (stateX == 2) message = "S2";
    Console.WriteLine("Now in State " + message);
  }

  private static void new_stateY(int newState)
  {
    stateY = newState;
    string message = "";
    if (stateY == 0) message = "SA";
    if (stateY == 2) message = "SB";
    Console.WriteLine("Now in State " + message);
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

  /* ---------------------------------------------------------------------------------------------------------------------
  MAIN
  --------------------------------------------------------------------------------------------------------------------- */

  static void Main()
  {
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
      // Set Row and Column Values;
      // X FSM
      rowX = keyEvent;
      colX = stateX;
      // Y FSM
      rowY = keyEvent;
      colY = stateX + stateY;
      // If Event Driven Key Press
      if (keyEvent >= 0)
      {
        // Execute the Actions
        // X FSM
        execute(FST_X[rowX, colX].action1);
        execute(FST_X[rowX, colX].action2);
        execute(FST_X[rowX, colX].action3);
        // Y FSM
        execute(FST_Y[rowY, colY].action1);
        execute(FST_Y[rowY, colY].action2);
        execute(FST_Y[rowY, colY].action3);
        // Evaluate if there is a change of state
        // X FSM
        if (stateX != FST_X[rowX, colX].nextState)
        {
          new_stateX(FST_X[rowX, colX].nextState);
        }
        // Y FSM
        if (stateY != FST_Y[rowY, colY].nextState)
        {
          new_stateY(FST_Y[rowY, colY].nextState);
        }
      }
    }
  }
}