using System;

namespace ConsoleGraph
{
    class Program
    {
        private static string[,] graph;
        private static int Xsize = 40, Ysize = 20;
        static void Main(string[] args)
        {
            graph = new string[Xsize, Ysize];
            
            for (int x = 0; x < Xsize; x++)
            {
                int y = Function(x) < Ysize? Function(x) : Ysize - 1;
                //Console.WriteLine(x + "  " + y);
                graph[x, y] = "AA";
            }
            PrintMap();
            Console.ReadKey();
        }

        static int Function(int x)
        {
            int y;
            y = (int)(x / 2);
            return y;
        }

        static void PrintMap()
        {
            for (int y = Ysize - 1; y > 0; y--)
            {
                for (int x = 0; x < Xsize; x++)
                {
                    string cell = string.IsNullOrEmpty(graph[x, y]) ? "  " : graph[x, y] ;
                    Console.Write(cell);
                }
                Console.WriteLine("");
            }
        }
    }
}