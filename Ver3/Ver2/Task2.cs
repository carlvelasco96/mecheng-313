using System;
using System.Collections.Generic;
using System.Threading;

public class Task2
{
    //define the indexes of the states and the events
    private const int S0 = 0;
    private const int S1 = 1;
    private const int S2 = 2;
    private const int E0 = 0;
    private const int E1 = 1;
    private const int E2 = 2;


    //initialise log
    static List<string> actionLog = new List<string>();

    static public void ActionW()
    {
        Console.WriteLine("Action W");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionW Executed");
    }

    static public void ActionX()
    {
        Console.WriteLine("Action X");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionX Executed");
    }

    static public void ActionY()
    {
        Console.WriteLine("Action Y");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionY Executed");
    }

    static public void ActionZ()
    {
        Console.WriteLine("Action Z");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionZ Executed");
    }

    static public void ActionJ()
    {
        Console.WriteLine("Action J");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionJ Executed");
    }

    static public void ActionK()
    {
        Console.WriteLine("Action K");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionK Executed");
    }

    static public void ActionL()
    {
        Console.WriteLine("Action L");
        string time = System.DateTime.Now.ToString();
        actionLog.Add(time + " ActionL Executed");
    }

    static public void NoAction()
    {
        //do nothing
    }

    public static void execute(string actions)
    {
        if (actions == "ActionJ,ActionK,ActionL")
        {
            Thread thr1 = new Thread(() => ActionJ());
            Thread thr2 = new Thread(() => ActionK());
            Thread thr3 = new Thread(() => ActionL());
            //start simultaneously
            thr1.Start();
            thr2.Start();
            thr3.Start();
            //stop executing main thread until done
            thr1.Join();
            thr2.Join();
            thr3.Join();
        }
        else
        {
            string[] separatedActions = actions.Split(",");
            for (int j = 0; j < 3; j++)
            {
                if (separatedActions[j] == "ActionW") { ActionW(); }
                if (separatedActions[j] == "ActionX") { ActionX(); }
                if (separatedActions[j] == "ActionY") { ActionY(); }
                if (separatedActions[j] == "ActionZ") { ActionZ(); }
                if (separatedActions[j] == "ActionJ") { ActionJ(); }
                if (separatedActions[j] == "ActionK") { ActionK(); }
                if (separatedActions[j] == "ActionL") { ActionL(); }
                if (separatedActions[j] == "NoAction") { NoAction(); }
            }
        }
    }

    public static void quit(string filePath)
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
        //set up the FST
        FiniteStateTable FST_Task_2 = new FiniteStateTable();
        FST_Task_2.SetNextState(S0, E0, S1);
        FST_Task_2.SetActions(S0, E0, "ActionX", "ActionY");
        FST_Task_2.SetNextState(S1, E0, S0);
        FST_Task_2.SetActions(S1, E0, "ActionW");
        FST_Task_2.SetNextState(S2, E0, S0);
        FST_Task_2.SetActions(S2, E0, "ActionW");
        FST_Task_2.SetNextState(S1, E1, S2);
        FST_Task_2.SetActions(S1, E1, "ActionX", "ActionZ");
        FST_Task_2.SetNextState(S2, E2, S1);
        FST_Task_2.SetActions(S2, E2, "ActionX", "ActionY");

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
                    execute(FST_Task_2.GetActions(FST_Task_2.state, keyEvent));

                    if (FST_Task_2.state != FST_Task_2.GetNextState(FST_Task_2.state, keyEvent))
                    {
                        FST_Task_2.state = FST_Task_2.GetNextState(FST_Task_2.state, keyEvent);
                        Console.WriteLine("Now in State " + FST_Task_2.state);
                        string timeStamp = System.DateTime.Now.ToString();
                        actionLog.Add(timeStamp + " Entered State " + FST_Task_2.state);
                    }

                }
                else if (keyEntered == 'q')
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