namespace Data.Engines
{
    using System;
    using System.Collections.Generic;
    using Interpreters;

    public class Engine : IEngine
    {

        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter command)
        {
            this.commandInterpreter = command;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    List<string> inputInfo = new List<string>();

                    int n = int.Parse(Console.ReadLine());

                    for (int i = 0; i < n; i++)
                    {
                        inputInfo.Add(Console.ReadLine());
                    }

                    bool IsReady = commandInterpreter.CreateLogger(inputInfo);

                    if (IsReady)
                    {
                        inputInfo.Clear();

                        string command;

                        while ((command = Console.ReadLine()) != "END")
                        {
                            inputInfo.Add(command);
                        }

                        commandInterpreter.AppendMessages(inputInfo);

                        commandInterpreter.PrintInfo();

                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
