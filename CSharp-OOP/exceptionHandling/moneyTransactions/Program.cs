using System;
using System.Collections.Generic;
using System.Linq;

namespace moneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> acc = new Dictionary<int, double>();
            string[] strArr = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < strArr.Length; i++)
            {
                string[] curr = strArr[i].Split('-', StringSplitOptions.RemoveEmptyEntries);
                int num = int.Parse(curr[0]);
                double balance = double.Parse(curr[1]);
                acc.Add(num, balance);
            }
            string command = Console.ReadLine();
            while (true)
            {
                string[] tokens = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                if (tokens[0].StartsWith("End"))
                {
                    break;
                }
                try
                {
                    int num = int.Parse(tokens[1]);

                    double sum = double.Parse(tokens[2]);

                    if (!acc.ContainsKey(num))
                    {
                        throw new InvalidOperationException("Invalid account!");
                    }
                    if (tokens[0] == "Deposit")
                    {
                        acc[num] += sum;
                        Console.WriteLine($"Account {num} has new balance: {acc[num]:f2}");
                    }
                    else if (tokens[0] == "Withdraw")
                    {
                        if (acc[num] < sum)
                        {
                            throw new InvalidOperationException("Insufficient balance!");
                        }
                        else
                        {
                            acc[num] -= sum;
                            Console.WriteLine($"Account {num} has new balance: {acc[num]:f2}");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                    command = Console.ReadLine();
                }
            }
        }
    }
}
