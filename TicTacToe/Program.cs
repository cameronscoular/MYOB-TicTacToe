using System;

namespace TicTacToe
{
    class Program
    {

        static Boolean GameInProgress = true;
        static int PlayerTurn = 1;
        static string[] PlayerPieces = new string[] { "X", "O" };
        static int[] PlayerBoardNumbers = new int[] { 1, -1 };
        static string[] ValidCoords = new string[] { "1", "2", "3" };
        static int[,] Board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Tic Tac Toe!");

            while (GameInProgress)
            {
                Console.WriteLine("Here is the current board");
                WriteBoard();

                PlayNextTurn();

                CheckWinCondition();

            }


        }

        static void PlayNextTurn()
        {

            Console.WriteLine("Player " + PlayerTurn + " enter a coord x,y to place your " + PlayerPieces[PlayerTurn - 1] + " or enter 'q' to quit: ");

            var input = Console.ReadLine().Replace(" ", string.Empty).ToLower();

            if (input.Equals("q"))
            {
                Console.WriteLine("Quitting game...");
                Environment.Exit(0);
            }

            string[] coords = input.Split(",");

            if( coords.Length != 2 || Array.IndexOf(ValidCoords, coords[0]) == -1 || Array.IndexOf(ValidCoords, coords[1]) == -1)
            {
                Console.WriteLine("Sorry Player " + PlayerTurn + ", these are not valid coordinates. Please try again...");
                return;
            }

            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);

            if( Board[x - 1, y - 1] != 0)
            {
                Console.WriteLine("Sorry Player " + PlayerTurn + ", a piece is already at this place. Please try again...");
                Console.WriteLine("");
                return;
            }


            Board[x - 1, y - 1] = PlayerBoardNumbers[PlayerTurn - 1];

            Console.WriteLine("Move accepted");

            ChangePlayerTurn();

        }

        static void CheckWinCondition()
        {

        }

        static void ChangePlayerTurn()
        {
            if( PlayerTurn == 1)
            {
                PlayerTurn = 2;
            }else if( PlayerTurn == 2)
            {
                PlayerTurn = 1;
            }
        }

        static void WriteBoard()
        {

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {

                    if(Board[i, j] == 0)
                    {
                        Console.Write(". ");
                    }else if(Board[i, j] == 1)
                    {
                        Console.Write("X ");
                    }else if(Board[i, j] == -1)
                    {
                        Console.Write("O ");
                    }

                }
                Console.WriteLine("");
            }

        }

    }
}
