using System;

namespace TicTacToe
{
    class Program
    {

        static int PlayerTurn = 1;

        static string[] PlayerPieces = new string[] { "X", "O" };
        static int[] PlayerBoardNumbers = new int[] { 1, -1 };

        static string[] ValidCoords = new string[] { "1", "2", "3" };

        static int[,] Board = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };

        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Tic Tac Toe!");

            while (true)
            {
                Console.WriteLine("Here is the current board");

                WriteBoard();

                PlayNextTurn();

                CheckWinCondition();

            }

        }

        static void PlayNextTurn()
        {

            //Retrieving player input
            Console.WriteLine("Player " + PlayerTurn + " enter a coord x,y to place your " + PlayerPieces[PlayerTurn - 1] + " or enter 'q' to quit: ");
            var input = Console.ReadLine().Replace(" ", string.Empty).ToLower();

            // Quitting game if "q" entered
            if (input.Equals("q"))
            {
                Console.WriteLine("Quitting game...");
                Environment.Exit(0);
            }

            // Parsing and validating user input

            string[] coords = input.Split(",");

            if( coords.Length != 2 || Array.IndexOf(ValidCoords, coords[0]) == -1 || Array.IndexOf(ValidCoords, coords[1]) == -1)
            {
                Console.WriteLine("Sorry Player " + PlayerTurn + ", these are not valid coordinates. Please try again...");
                Console.WriteLine("");
                return;
            }

            int x = int.Parse(coords[0]);
            int y = int.Parse(coords[1]);

            // Checking there is no piece at the coordinates
            if( Board[x - 1, y - 1] != 0)
            {
                Console.WriteLine("Sorry Player " + PlayerTurn + ", a piece is already at this place. Please try again...");
                Console.WriteLine("");
                return;
            }

            // Placing the piece
            Board[x - 1, y - 1] = PlayerBoardNumbers[PlayerTurn - 1];

            Console.WriteLine("Move accepted");
            Console.WriteLine("");

            ChangePlayerTurn();

        }

        static void CheckWinCondition()
        {
            // Variable which checks whether there are any free spaces left on the board for checking for a draw
            bool emptySpacesLeft = false;

            // Loop used to check rows and columns for completed row
            for (int i = 0; i < 3; i++)
            {
                int colSum = 0;
                int rowSum = 0;
                for (int j = 0; j < 3; j++)
                {
                    rowSum += Board[i, j];
                    colSum += Board[j, i];
                    if (Board[i, j] == 0)
                    {
                        emptySpacesLeft = true;
                    }
                }

                // Checking row/column sums for winner
                if (rowSum == 3 || colSum == 3)
                {
                    EndWonGame(1);
                } else if (rowSum == -3 || colSum == -3)
                {
                    EndWonGame(2);
                }

            }

            // Checking diagonal sums for winner
            int firstDiagonalSum = Board[0, 0] + Board[1, 1] + Board[2, 2];
            int secondDiagonalSum = Board[2, 0] + Board[1, 1] + Board[0, 2];

            if( firstDiagonalSum == 3 || secondDiagonalSum == 3 )
            {
                EndWonGame(1);
            }else if( firstDiagonalSum == -3 || secondDiagonalSum == -3)
            {
                EndWonGame(2);
            }

            // Drawing if there are no empty spaces on the board and there is no winner
            if( !emptySpacesLeft )
            {
                EndDrawnGame();
            }

        }

        static void EndWonGame(int winningPlayer)
        {
         
            Console.WriteLine("Well done! Player " + winningPlayer + " has won the game!");
            WriteBoard();
            Console.WriteLine("Now ending the game...");
            Environment.Exit(0);
        }

        static void EndDrawnGame()
        {
            Console.WriteLine("The game is a draw!");
            WriteBoard();
            Console.WriteLine("Ending the game...");
            Environment.Exit(0);
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
