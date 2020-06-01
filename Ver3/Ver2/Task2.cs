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

    /// <summary>
    /// performs action w and logs it
    /// </summary>
    static public void ActionW()
    {
        Console.WriteLine("Action W");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionW Executed"); //log it
    }

    /// <summary>
    /// performs action x and logs it
    /// </summary>
    static public void ActionX()
    {
        Console.WriteLine("Action X");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionX Executed"); //log it
    }

    /// <summary>
    /// performs action y and logs it
    /// </summary>
    static public void ActionY()
    {
        Console.WriteLine("Action Y");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionY Executed"); //log it
    }

    /// <summary>
    /// performs action z and logs it
    /// </summary>
    static public void ActionZ()
    {
        Console.WriteLine("Action Z");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionZ Executed"); //log it
    }

    /// <summary>
    /// performs action j and logs it
    /// </summary>
    static public void ActionJ()
    {
        Console.WriteLine("Action J");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionJ Executed"); //log it
    }

    /// <summary>
    /// performs action k and logs it
    /// </summary>
    static public void ActionK()
    {
        Console.WriteLine("Action K");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionK Executed"); //log it
    }

    /// <summary>
    /// performs action L and logs it
    /// </summary>
    static public void ActionL()
    {
        Console.WriteLine("Action L");
        string time = System.DateTime.Now.ToString(); //get timestamp
        actionLog.Add(time + " ActionL Executed"); //log it
    }

    /// <summary>
    /// does nothing
    /// not strictly necessary but good practice?
    /// </summary>
    static public void NoAction()
    {
        //do nothing
    }

    /// <summary>
    /// parses string of actions and executes the corresponding method
    /// </summary>
    /// <param name="actions">string of actions to be performed, separated by commas</param>
    public static void execute(string actions)
    {
        //multithread if actions j,k,l are all called
        if (actions == "ActionJ,ActionK,ActionL")
        {
            //create separate threads
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
        else //execute normally
        {
            //split into three actions
            string[] separatedActions = actions.Split(",");
            //execute actions
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

    /// <summary>
    /// stores all logs to the file path specified and exits the programme
    /// </summary>
    /// <param name="filePath">path of log file</param>
    public static void quit(string filePath)
    {
        //convert log list to one string
        string log = "";
        for (int i = 0; i < actionLog.Count; i++)
        {
            log += actionLog[i] + "\n";
        }
        //write to file
        System.IO.File.WriteAllText(@filePath, log);
        //close console
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

        //set up local variables
        char keyEntered = '0';
        int keyEvent;

        while (true)
        {
            //Read single characters 
            keyEntered = (char)Console.Read();
            keyEvent = -1;

            //interpret events
            if (keyEntered == ('a')) keyEvent = E0;
            if (keyEntered == ('b')) keyEvent = E1;
            if (keyEntered == ('c')) keyEvent = E2;
            if (keyEntered == ('q')) keyEvent = 4;

            //if a valid key has been entered
            if (keyEvent >= 0)
            {
                //log key reception
                string time = System.DateTime.Now.ToString();
                actionLog.Add(time + " User Entered: " + keyEntered);

                //execute corresponding actions to commands and update stae
                if ((keyEntered == 'a') || (keyEntered == 'b') || (keyEntered == 'c'))
                {
                    //execute actions
                    execute(FST_Task_2.GetActions(FST_Task_2.state, keyEvent));

                    //update state
                    if (FST_Task_2.state != FST_Task_2.GetNextState(FST_Task_2.state, keyEvent))
                    {
                        FST_Task_2.state = FST_Task_2.GetNextState(FST_Task_2.state, keyEvent);
                        Console.WriteLine("Now in State " + FST_Task_2.state);
                        //log state change
                        string timeStamp = System.DateTime.Now.ToString();
                        actionLog.Add(timeStamp + " Entered State " + FST_Task_2.state);
                    }

                }
                else if (keyEntered == 'q') //if quit command is entered
                {
                    //acquire log file path
                    Console.WriteLine("Please enter the file path of the file where you wish to have activity logged");
                    string filePath = "";
                    while (filePath == "")
                    {
                        filePath = Console.ReadLine();
                    }

                    //execute logging and closing sequence
                    try
                    {
                        quit(filePath);
                    }
                    catch
                    {
                        Console.WriteLine("Something went wrong, please try again");
                    }
                }
                
            }
        }
    }
}