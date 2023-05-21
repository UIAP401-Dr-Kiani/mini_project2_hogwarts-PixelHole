using System;
using System.Linq;

namespace KianiProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int len = Convert.ToInt32(Console.ReadLine());
            decimal[] nums = new Decimal[len];
            
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = Convert.ToDecimal(Console.ReadLine());
            }

            string min = $"{nums.Min():0.0000}";
            min = min.Remove(min.Length - 1);
            string max = $"{nums.Max():0.0000}";
            max = max.Remove(max.Length - 1);
            string avg = $"{nums.Average():0.0000}";
            avg = avg.Remove(avg.Length - 1);
            
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Avg: " + avg);
        }
    }
}