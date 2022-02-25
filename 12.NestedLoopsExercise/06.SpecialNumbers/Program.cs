using System;

namespace _06.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1111; i <= 9999; i++)
            {
                int th = i / 1000;
                int hu = i / 100 % 10;
                int te = i / 10 % 10;
                int un = i % 10;

                bool check1 = th != 0 && n % th == 0;
                bool check2 = hu != 0 && n % hu == 0;
                bool check3 = te != 0 && n % te == 0;
                bool check4 = un != 0 && n % un == 0;

                if (check1 && check2 && check3 && check4)
                {
                    Console.Write(i + " ");
                }
            }
            //for (int th = 1; th <= 9; th++)
            //{
            //    for (int hu = 1; hu <= 9; hu++)
            //    {
            //        for (int te = 1; te <= 9; te++)
            //        {
            //            for (int un = 1; un <= 9; un++)
            //            {
            //                bool check1 = n % th == 0;
            //                bool check2 = n % hu == 0;
            //                bool check3 = n % te == 0;
            //                bool check4 = n % un == 0;
            //
            //                if(check1 && check2 && check3 && check4)
            //                {
            //                    Console.Write($"{th}{hu}{te}{un} ");
            //                }
            //            }
            //        }
            //    }
            //}
        }
    }
}
