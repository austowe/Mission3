using System;

namespace Mission3
{
    class Driver
    {
        // player 1 = x player 2 = o
        static void Main(string[] args)
        {
            Ticker TKR = new Ticker();
            Console.WriteLine("Welcome to the game dude!");
            int[] game_board = new int[9];
            TKR.printBoard(game_board);

            for (int i = 0; i < 10; i++)
            {
                int winCheck = TKR.winCheck(game_board);
                if (winCheck == 4)
                {
                    if (i % 2 == 0)
                    {
                        Console.WriteLine("X's Choice: ");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        bool exists = Array.Exists(game_board, element => element == answer);
                        while (exists)
                        {
                            Console.WriteLine("Already Chosen. X's Choice: ");
                            int new_answer = Convert.ToInt32(Console.ReadLine());
                            exists = Array.Exists(game_board, element => element == new_answer);
                            if (!exists)
                            {
                                game_board[new_answer - 1] = (2);
                                TKR.printBoard(game_board);
                            }
                        }
                        game_board[answer - 1] = (2);
                        TKR.printBoard(game_board);
                    }
                    else
                    {
                        Console.WriteLine("O's Choice: ");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        bool exists = Array.Exists(game_board, element => element == answer);
                        while (exists)
                        {
                            Console.WriteLine("Already Chosen. O's Choice: ");
                            int new_answer = Convert.ToInt32(Console.ReadLine());
                            exists = Array.Exists(game_board, element => element == new_answer);
                            if (!exists)
                            {
                                game_board[new_answer - 1] = (1);
                                TKR.printBoard(game_board);
                            }
                        }
                        game_board[answer - 1] = (1);
                        TKR.printBoard(game_board);
                    }
                }
                else if (winCheck == 1)
                {
                    Console.WriteLine("X's Wins!");
                    break;
                }
                else if (winCheck == 2)
                {
                    Console.WriteLine("O's Wins!");
                    break;
                }
                else
                {
                    Console.WriteLine("It's a Draw!");
                    break;
                }
            }
        }
    }
}
