using System;

namespace Fizzbuzz
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            for (int num = 1; num < 101; num++)
            {
                string msg = "";
                if (num % 3 == 0)
                {
                    msg = msg.Insert(msg.Length,"Fizz");
                }
                if (num % 5 == 0)
                {
                    msg = msg.Insert(msg.Length,"Buzz");
                }
                if (msg.Length == 0)
                {
                    msg = num.ToString();
                }
                Console.WriteLine(msg);
            }
        }
    }
}