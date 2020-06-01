using System;
using System.Collections.Generic;

public class Task2
{
    ////define the indexes of the states and the events
    //public const int S0 = 0;
    //public const int S1 = 1;
    //public const int S2 = 2;
    //public const int E0 = 0;
    //public const int E1 = 1;
    //public const int E2 = 2;


    ////initialise log
    //static List<string> actionLog = new List<string>();

    //static private void ActionW()
    //{
    //    Console.WriteLine("Action W");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionW Executed");
    //}

    //static private void ActionX()
    //{
    //    Console.WriteLine("Action X");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionX Executed");
    //}

    //static private void ActionY()
    //{
    //    Console.WriteLine("Action Y");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionY Executed");
    //}

    //static private void ActionZ()
    //{
    //    Console.WriteLine("Action Z");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionZ Executed");
    //}

    //static private void ActionJ()
    //{
    //    Console.WriteLine("Action J");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionJ Executed");
    //}

    //static private void ActionK()
    //{
    //    Console.WriteLine("Action K");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionK Executed");
    //}

    //static private void ActionL()
    //{
    //    Console.WriteLine("Action L");
    //    string time = System.DateTime.Now.ToString();
    //    actionLog.Add(time + " ActionL Executed");
    //}

    //static private void NoAction()
    //{
    //    //do nothing
    //}

    //private static void execute(string action)
    //{
    //    if (action == "NoAction") { NoAction(); }
    //    if (action == "ActionW") { ActionW(); }
    //    if (action == "ActionX") { ActionX(); }
    //    if (action == "ActionY") { ActionY(); }
    //    if (action == "ActionZ") { ActionZ(); }
    //    if (action == "ActionJ") { ActionJ(); }
    //    if (action == "ActionK") { ActionK(); }
    //    if (action == "ActionL") { ActionL(); }
    //}

    //private static void quit(string filePath)
    //{
    //    string log = "";
    //    for (int i = 0; i < actionLog.Count; i++)
    //    {
    //        log += actionLog[i] + "\n";
    //    }
    //    System.IO.File.WriteAllText(@filePath, log);
    //    System.Environment.Exit(0);
    //}
    public Task2()
    {
        Console.WriteLine("hjellp");
        ////set up the FST
        //FiniteStateTable FST_Task_2 = new FiniteStateTable();
        //FST_Task_2.SetNextState(S0, E0, S1);
        //FST_Task_2.SetActions(S0, E0, "ActionX", "ActionY");
        //FST_Task_2.SetNextState(S1, E0, S0);
        //FST_Task_2.SetActions(S1, E0, "ActionW");
        //FST_Task_2.SetNextState(S2, E0, S0);
        //FST_Task_2.SetActions(S2, E0, "ActionW");
        //FST_Task_2.SetNextState(S1, E1, S2);
        //FST_Task_2.SetActions(S1, E1, "ActionX", "ActionZ");
        //FST_Task_2.SetNextState(S2, E2, S1);
        //FST_Task_2.SetActions(S2, E2, "ActionX", "ActionY");

        //char keyEntered = '0';
        //int keyEvent;

        //while (true)
        //{
        //    keyEntered = (char)Console.Read();
        //    keyEvent = -1;
        //    if (keyEntered == ('a')) keyEvent = E0;
        //    if (keyEntered == ('b')) keyEvent = E1;
        //    if (keyEntered == ('c')) keyEvent = E2;
        //    if (keyEntered == ('q')) keyEvent = 4;
        //    if (keyEvent >= 0)
        //    {
        //        string time = System.DateTime.Now.ToString();
        //        actionLog.Add(time + " User Entered: " + keyEntered);

        //        if ((keyEntered == 'a') || (keyEntered == 'b') || (keyEntered == 'c'))
        //        {
        //            execute(FST_Task_2.GetActions(FST_Task_2.state, keyEvent, 1));
        //            execute(FST_Task_2.GetActions(FST_Task_2.state, keyEvent, 2));
        //            execute(FST_Task_2.GetActions(FST_Task_2.state, keyEvent, 3));

        //            if (FST_Task_2.state != FST_Task_2.GetNextState(FST_Task_2.state, keyEvent))
        //            {
        //                FST_Task_2.state = FST_Task_2.GetNextState(FST_Task_2.state, keyEvent);
        //                Console.WriteLine("Now in State " + FST_Task_2.state);
        //                string timeStamp = System.DateTime.Now.ToString();
        //                actionLog.Add(timeStamp + " Entered State " + FST_Task_2.state);
        //            }

        //        }
        //        else if (keyEntered == 'q')
        //        {
        //            Console.WriteLine("Please enter the file path of the file where you wish to have activity logged");
        //            string filePath = "";
        //            while (filePath == "")
        //            {
        //                filePath = Console.ReadLine();
        //            }
        //            try
        //            {
        //                quit(filePath);
        //            }
        //            catch
        //            {
        //                Console.WriteLine("File path not recognised, please try again");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Command not recognised. Please try again.");
        //        }
        //    }
        //}
    }
}