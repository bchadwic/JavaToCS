using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace JavaToCS
{
    class IO
    {
        public IO()
        {

        }

        public char getMarker()
        {
            Console.Write("Enter a marker: ");
            return Console.ReadLine()[0];
        }

        public int[] getLocation(Player player)
        {
            Console.WriteLine($"{player.getName()}, pick a valid coordinate");
            int[] location = new int[2];
            string[] locationTypes = { "row", "col" };
            for(int i = 0; i < 2;)
            {
                Console.Write($"Enter the {locationTypes[i]}: ");
                char c = Console.ReadLine()[0];
                int axis = c - '0'; 
                if (axis >= 0 && axis <= 2)
                {
                    location[i++] = axis;
                }
            }
            return location;
        }

        public string getName()
        {
            Console.Write("Enter a new player's name: ");
            return Console.ReadLine();
        }

        public void printBoard(Board board)
        {
            Console.Clear();
            char[,] cboard = board.getBoard();
            Console.WriteLine("   0  1  2");
            for (int row = 0; row < 3; row++)
            {
                Console.Write(row + "  ");
                for (int col = 0; col < 3; col++)
                {
                    if (cboard[row, col] == ' ')
                    {
                        Console.Write("_  ");
                    }
                    else
                    {
                        Console.Write(cboard[row, col] + "  ");
                    }
                }
                Console.WriteLine();
            }

        }

        public bool playAgain()
        {
            char confirm;
            do
            {
                Console.Write("Play again? (y/n): ");
                confirm = Console.ReadLine()[0];
            } while (confirm != 'y' && confirm != 'n');
            Console.Clear();
            return confirm == 'y';
        }
    }
}
