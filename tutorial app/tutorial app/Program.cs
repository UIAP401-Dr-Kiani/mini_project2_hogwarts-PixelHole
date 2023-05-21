using System;

namespace tutorial_app
{
    internal class Program
    {
        public static Random Random = new Random();
        
        public static int size;
        public static int bombamount;
        public static String[,] field;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter size");
            size = int.Parse(Console.ReadLine());
            
            field = new String[size,size];
            
            Console.WriteLine("Enter bomb amount");
            bombamount = int.Parse(Console.ReadLine());

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    field[j, i] = "0";
                }
            }

            int randy;
            int randx;

            while (bombamount > 0)
            {
                randx = Random.Next(size - 1);
                randy = Random.Next(size - 1);

                field[randx, randy] = "B";
                bombamount--;
                
                for (int y = -1; y < 2; y++)
                {
                    for (int x = -1; x < 2; x++)
                    {
                        if (randx + x > -1 && randx + x < size -1 && randy + y > -1 && randy + y < size -1)
                        {
                            if (!(x == 0 && y == 0))
                            {
                                int cellvalue = int.Parse(field[randx + x, randy + y]) + 1;
                                field[randx + x, randy + y] = cellvalue.ToString();
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < size - 1; i++)
                {
                    for (int j = 0; j < size - 1; j++)
                    {
                        Console.Write(field[j, i] + " ");
                    }

                    Console.WriteLine("");
                }
            }
    }
}