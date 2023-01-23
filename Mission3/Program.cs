using System;

namespace Mission3
{
    class Driver
    {
        // player 1 = x palyer 2 = o
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the game dude!");
            int[] game_board = new int[9];
            printBoard(game_board);

            int winCheck = winCheck();

            if (winCheck == 4)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine("Player 1 Choice: ");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        bool exists = Array.Exists(game_board, element => element == answer);
                        if (exists)
                        {
                            Console.WriteLine("Already Chosen. Player 1 Choice: ");
                            game_board[i] = Convert.ToInt32(Console.ReadLine());
                            printBoard(game_board);

                        }
                        else
                        {
                            game_board[i] = answer;
                            printBoard(game_board);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Choice: ");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        bool exists = Array.Exists(game_board, element => element == answer);
                        if (exists)
                        {
                            Console.WriteLine("Already Chosen. Player 2 Choice: ");
                            game_board[i] = Convert.ToInt32(Console.ReadLine());
                            printBoard(game_board);
                        }
                        else
                        {
                            game_board[i] = answer;
                            printBoard(game_board);
                        }
                    }
                }

            }
            else if (winCheck == 1)
            {
                Console.WriteLine("Player 1 Wins!");
            }
            else if (winCheck == 2)
            {
                Console.WriteLine("Player 2 Wins!");
            }
            else 
            {
                Console.WriteLine("It's a Draw!");
            }
        }
    }
}
