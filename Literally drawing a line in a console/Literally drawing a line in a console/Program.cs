#nullable enable
using System;

namespace Literally_drawing_a_line_in_a_console
{
    class Program
    {
        private static bool isRunning = true;
        private static int xsize, ysize;
        private static int[,] grid;
        private static string[] tiles =
        {
            "░░",
            "OO"
        };

        private static ConsoleColor[] colors =
        {
            ConsoleColor.White,
            ConsoleColor.DarkGray,
            ConsoleColor.White
        };

        static void Main(string[] args)
        {
            LineDrawer();
        }

        private static void LineDrawer()
        {
            CreateGrid();
            PrintGrid(true);
            AwaitForCommand();
        }
        private static void AwaitForCommand()
        {
            while (isRunning)
            {
                decipherCommand(GetInput("Awaiting Command:"));
            }
        }
        private static void decipherCommand(string command)
        {
            if (command.StartsWith("place"))
            {
                int x = command[6] - '0';
                int y = command[8] - '0';
                int v = command[10] - '0';
                
                PlacePoint(x, y , v);
                PrintGrid(true);
            }
            if (command.StartsWith("line"))
            {
                int x1 = command[5] - '0';
                int y1 = command[7] - '0';
                int x2 = command[9] - '0';
                int y2 = command[11] - '0';
                int v = command[13] - '0';
                
                drawLine(x1, y1, x2, y2, v);
                PrintGrid(true);
            }
            if (command.StartsWith("clear"))
            {
                PrintGrid(true);
            }
            if (command.StartsWith("exit"))
            {
                isRunning = false;
            }
        }
        private static void drawLine(int x1, int y1, int x2, int y2, int value)
        {
            int m = (y2 - y1) / (x2 - x1);
            int b = y2 - m * x2;
            for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)
            {
                int y = (m * x + b);
                if (y >= 0 && y < ysize )
                {
                    PlacePoint(x, y, value);
                }
            }
        }
        private static void PlacePoint(int x, int y, int value)
        {
            grid[x, y] = value;
        }
        private static void CreateGrid()
        {
            if (GetInput("def?").Equals("y"))
            {
                xsize = 20;
                ysize = 20;
            }
            else
            {
                xsize = int.Parse(GetInput("X size?"));
                ysize = int.Parse(GetInput("Y size?"));
            }
            grid = new int[xsize, ysize];
        }
        private static void PrintGrid(bool clear)
        {
            if (clear)
            {
                Console.Clear();
            }
            for (int y = ysize - 1; y >= 0; y--)
            {
                for (int x = 0; x < xsize; x++)
                {
                    Console.ForegroundColor = colors[grid[x, y] + 1];
                    Console.Write(tiles[grid[x,y]]);
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = colors[0];
        }
        public static string GetInput(string? message)
        {
            string input = "";
            Console.WriteLine(message);
            input = Console.ReadLine();
            if (input == null)
            {
                input = "";
            }
            return input;
        }
    }
    
    class vector2
    {
        public static int x, y;
    }
}