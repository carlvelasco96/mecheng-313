using System;

class FiniteStateTable
{
    public const int S0 = 0;
    public const int S1 = 1;
    public const int S2 = 2;
    public const int E0 = 0;
    public const int E1 = 1;
    public const int E2 = 2;

    int state = S0;

    struct cell_FST //groups variables of a cell (indexOfNextState and 2 actions)
    {
        public int nextState;
        public void action1;
        public void action2;
    }

    cell_FST[3, 3] FST_X = {
    // S0                           S1                          S2
    { {S1, ActionX, ActionY},       {S0, ActionW, NoAction},    {S0, ActionW, NoAction} },  //E0
    { {S0, NoAction, NoAction},     {S2, ActionX, ActionZ},     {S2, NoAction, NoAction} }, //E1
    { {S2, NoAction, NoAction},     {S1, NoAction, NoAction},   {S1, ActionX, ActionY} },   //E2
    };

    // 

    //set indexOfNextState of cell
    public void SetNextState(int state, int eventIndex, int newIndexOfNextState)
    {
        FST_X(state, 2).nextState = newIndexOfNextState;
    }

    //set action of cell
    public void SetActions(int state, int eventIndex, string newAction)
    {
        FST_X(state, 2).action = newAction;
    }

    //return indexOfNextState of cell
    public string GetNextState(int stateIndex)
    {
        return FST_X(state, 2).indexOfNextState;
    }

    //return action of cell
    public string GetActions(int stateIndex)
    {
        return FST_X(state, 1).action;
    }

    private void ActionW()
    {
        Console.Write("Action W");
    }

    private void ActionX()
    {
        Console.Write("Action X");
    }

    private void ActionY()
    {
        Console.Write("Action Y");
    }

    private void ActionZ()
    {
        Console.Write("Action Z");
    }

    private void ActionJ()
    {
        Console.Write("Action J");
    }

    private void ActionK()
    {
        Console.Write("Action K");
    }

    private void ActionL()
    {
        Console.Write("Action L");
    }

    private void NoAction()
    {
        //do nothing
    }

    private void new_state(int newState)
    {
        state = newState;
        Console.WriteLine("Now in State " + state);
    }

    void Main()
    {
        char keyEntered = '0';
        int keyEvent;

        while (1)
        {
            keyEntered = Console.ReadKey();
            keyEvent = -1;
            if (keyEntered == ("a")) keyEvent = E0;
            if (keyEntered == ("b")) keyEvent = E1;
            if (keyEntered == ("c")) keyEvent = E2;
            if (keyEvent > 0)
            {
                FST_X[keyEntered][state].action1();
                FST_X[keyEntered][state].action2();

                if (state != FST_X[keyEntered][state].nextState)
                {
                    new_state(FST_X[keyEntered][state].nextState);
                }
            }
        }
    }

}