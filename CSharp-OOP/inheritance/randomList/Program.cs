using System;
using System.Collections.Generic;

namespace CustomRandomList//randomList
{

    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            rnd = new Random();
        }

        public string RandomString()
        {
            int index = rnd.Next(0, this.Count);
            string str = this[index];
            this.RemoveAt(index);
            return str;
        }
    }

    public class StartUp//Program
    {
        static void Main(string[] args)
        {

        }
    }
}
