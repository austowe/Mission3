using System;

namespace Mission3
{
    class Driver
    {
        // player 1 = x player 2 = o
        static void Main(string[] args)
        {
            Ticker TKR = new Ticker();
            // Welcome Message
            Console.WriteLine("Welcome to the game dude!");
            int[] game_board = new int[9];
            TKR.printBoard(game_board);

            // Loop through each turn
            for (int i = 0; i < 10; i++)
            {
                // Check game progress, end it if there is a winner or draw
                int winCheck = TKR.winCheck(game_board);
                if (winCheck == 4)
                {
                    // Differentiate players based on assignment of 1 and 2
                    if (i % 2 == 0)
                    {
                        // Players enter their choice
                        Console.WriteLine("X's Choice: ");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        // Check if the number as been selected already
                        bool exists = Array.Exists(game_board, element => element == answer);
                        while (exists)
                        {
                            Console.WriteLine("The Selection " + answer + " Has Already Been Chosen. X Choose Again: ");
                            int new_answer = Convert.ToInt32(Console.ReadLine());
                            exists = Array.Exists(game_board, element => element == new_answer);
                            if (!exists)
                            {
                                // enter player entry into array game_board and print the state of the board
                                game_board[new_answer - 1] = (2);
                                TKR.printBoard(game_board);
                            }
                        }
                        // enter player entry into array game_board and print the state of the board
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
                            // Players enter their choice
                            Console.WriteLine("The Selection " + answer + " Has Already Been Chosen. O Choose Again: ");
                            int new_answer = Convert.ToInt32(Console.ReadLine());
                            // Check if the number as been selected already
                            exists = Array.Exists(game_board, element => element == new_answer);
                            if (!exists)
                            {
                                // enter player entry into array game_board and print the state of the board
                                game_board[new_answer - 1] = (1);
                                TKR.printBoard(game_board);
                            }
                        }
                        // enter player entry into array game_board and print the state of the board
                        game_board[answer - 1] = (1);
                        TKR.printBoard(game_board);
                    }
                }
                // game status checks
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
