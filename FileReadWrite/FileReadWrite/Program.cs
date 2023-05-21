using System.IO;

namespace FileReadWrite
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StreamWriter writer = new StreamWriter("NewFile1.txt");
            writer.WriteLine("tye");
            writer.Close();
        }
    }
}