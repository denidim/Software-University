using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> chat = new List<string>();

            while (input!="end")
            {
                List<string> commands = input.Split().ToList();

                for (int i = 0; i < commands.Count; i++)
                {
                    if (commands[i] == "Chat")
                    {
                        chat.Add(commands[i + 1]);
                    }
                    else if(commands[i] == "Delete")
                    {
                        if (chat.Contains(commands[i + 1]))
                        {
                            chat.Remove(commands[i + 1]);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if(commands[i] == "Edit")
                    {
                        string message = commands[i + 1];
                        string editVersion = commands[i + 2];
                        if (chat.Contains(message))
                        {
                            int indexOfMessage = chat.IndexOf(message);
                            chat.Insert(indexOfMessage, editVersion);
                            chat.Remove(message);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (commands[i] == "Pin")
                    {
                        string message = commands[i + 1];
                        if (chat.Contains(message))
                        {
                            chat.Remove(message);
                            chat.Add(message);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (commands[i] == "Spam")
                    {
                        int from = i+1;
                        int to = commands.Count - 1;

                        for (int j = from; j <= to; j++)
                        {
                            chat.Add(commands[j]);
                        }
                    }


                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < chat.Count; i++)
            {
                Console.WriteLine(chat[i]);
            }
        }
    }
}
