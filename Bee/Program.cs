using System;
using System.Linq;
using System.Collections.Generic;

namespace Bee
{
    class Program
    {
        static char[][] matrix;

        static string command;

        static int playerRow;
        static int playerCol;

        static int bonusRow;
        static int bonusCol;

        static int flowerCounter;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            matrix = new char[n][];

            InitializeMatrix(n, matrix);

            //string command;

            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "up":
                        Move(-1, 0);
                        break;
                    case "down":
                        Move(1, 0);
                        break;
                    case "left":
                        Move(0, -1);
                        break;
                    case "right":
                        Move(0, 1);
                        break;
                }
            }

            if (flowerCounter >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowerCounter} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowerCounter} flowers more");
            }
            PrintMatrix();
        }

        private static void InitializeMatrix(int n, char[][] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                char[] currentInput = Console.ReadLine()
                    .ToCharArray();
                matrix[row] = currentInput;

                for (int col = 0; col < currentInput.Length; col++)
                {
                    if (currentInput[col] == 'B')
                    {
                        playerRow = row;
                        playerCol = col;
                    }

                    if (currentInput[col] == 'O')
                    {
                        bonusRow = row;
                        bonusCol = col;
                    }
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length
                && col >= 0 && col < matrix.Length;
        }

        private static void Move(int row, int col)
        {
            if (IsInside(playerRow + row, playerCol + col))
            {
                if (matrix[playerRow][playerCol] == 'B')
                {
                    matrix[playerRow][playerCol] = '.';
                }

                playerRow += row;
                playerCol += col;

                if (matrix[playerRow][playerCol] == '.')
                {
                    matrix[playerRow][playerCol] = 'B';
                }

                if (matrix[playerRow][playerCol] == 'f')
                {
                    flowerCounter++;
                    matrix[playerRow][playerCol] = 'B';
                }

                else if (matrix[playerRow][playerCol] == 'O')
                {
                    matrix[playerRow][playerCol] = '.';

                    if (command == "up")
                    {
                        playerRow -= 1;

                        if (playerRow < 0)
                        {
                            playerRow = matrix.Length - 1;
                        }

                    }
                    else if (command == "down")
                    {
                        playerRow += 1;
                        
                    }
                    else if (command == "left")
                    {
                        playerCol -= 1;

                        if (playerCol < 0)
                        {
                            playerCol = matrix.Length - 1;
                        }
                    }
                    else if (command == "right")
                    {
                        playerCol += 1;
                        
                    }

                    if (matrix[playerRow][playerCol] == 'f')
                    {
                        flowerCounter++;
                    }
                    matrix[playerRow][playerCol] = 'B';
                }
            }
            else
            {
                matrix[playerRow][playerCol] = '.';
                Console.WriteLine($"The bee got lost!");
                if (flowerCounter >= 5)
                {
                    Console.WriteLine($"Great job, the bee managed to pollinate {flowerCounter} flowers!");
                }
                else
                {
                    Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowerCounter} flowers more");
                }
                PrintMatrix();
                Environment.Exit(0);
            }
        }
    }
}
