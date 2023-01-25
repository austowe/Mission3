using System;

// X == 1, O == 2

namespace Mission3
{
    class Driver
    {
        // player 1 = x player 2 = o
        static void Main(string[] args)
        {
            Console.Clear();

            Ticker TKR = new Ticker();
            // Welcome Message
            Console.WriteLine("Welcome to the game, dude(tte)!\n");
            int[] game_board = new int[9];
            int answer = 0;
            string playerLetter = "";
            int playerNumber = 0;
            bool isNumeric = false;


            // Loop through each turn
            for (int i = 0; i < 10; i++)
            {
                // Check game progress, end it if there is a winner or draw
                int winCheck = TKR.winCheck(game_board);
                if (winCheck == 4) // == continue game
                {

                    // Differentiate players based on assignment of 1 and 2
                    if (i % 2 == 0) { // X's turn
                        playerLetter = "X";
                        playerNumber = 1;
                            
                    } 
                    else if (i % 2 == 1) // O's turn
                    {
                        playerLetter = "O";
                        playerNumber = 2;
                    }

                    // Clears at beginning of each turn except the first
                    if (i != 0)
                    {
                        Console.Clear();
                    }

                    // Player enters their choice
                    TKR.printBoard(game_board);
                    Console.WriteLine("Player " + playerLetter + "'s turn! Enter your choice: ");

                    // NUMERIC 1-9 INPUT CHECK (same code used two times, could be moved to a separate function) ----------------------------
                    answer = 0;
                    isNumeric = false;
                    while (isNumeric == false)
                    {
                        // Using TryParse(): If the player input is a number, {isNumeric} will be true and {answer} will be set to the input.
                        // Otherwise, {isNumeric} will be false and {answer} will not be changed.
                        isNumeric = int.TryParse(Console.ReadLine(), out answer);

                        // Check if input is numeric AND is a number from 1-9
                        if ((isNumeric == true) && (1 <= answer && answer <= 9)) {
                            break;
                        }
                        else // If the input is invalid, player will be prompted again
                        {
                            Console.Clear();
                            Console.WriteLine("Still " + playerLetter + "'s Turn. Please enter a NUMBER from 1-9: ");
                            TKR.printBoard(game_board);
                            answer = 0;
                            isNumeric = false;
                        }
                    }// ---------------------------------------------------------------------------------------------------------------------

                    // OPEN SPOT CHECK
                    bool spotIsTaken = true;
                    while (spotIsTaken == true) // While player inputs a number that is already in the array/already taken
                    {
                        // If the location the player inputs already contains a player number (1 == X, 2 == O), {spotIsTaken} will be set to true
                        spotIsTaken = ((game_board[answer - 1] == 1) || (game_board[answer - 1] == 2));

                        if (spotIsTaken == false) // spot is available
                        {
                            // Enter player's number (1 == X, 2 == O) into {game_board) based on player's choice (answer - 1 = corresponding array index)
                            game_board[answer - 1] = playerNumber;
                        }
                        else // spot already taken
                        {
                            Console.Clear();
                            Console.WriteLine("Your selection, \"" + answer + "\" has already been chosen. Please try again, Player " + playerLetter + ": ");
                            TKR.printBoard(game_board);

                            // NUMERIC 1-9 INPUT CHECK (same code used two times, could be moved to a separate function) ----------------------------
                            answer = 0;
                            isNumeric = false;
                            while (isNumeric == false)
                            {
                                // Using TryParse(): If the player input is a number, {isNumeric} will be true and {answer} will be set to the input.
                                // Otherwise, {isNumeric} will be false and {answer} will not be changed.
                                isNumeric = int.TryParse(Console.ReadLine(), out answer);

                                // Check if input is numeric AND is a number from 1-9
                                if ((isNumeric == true) && (1 <= answer && answer <= 9)) {
                                    break;
                                }
                                else // If the input is invalid, player will be prompted again
                                {
                                    Console.Clear();
                                    Console.WriteLine("Still " + playerLetter + "'s Turn. Please enter a NUMBER from 1-9: ");
                                    TKR.printBoard(game_board);
                                    answer = 0;
                                    isNumeric = false;
                                }
                            }// ---------------------------------------------------------------------------------------------------------------------
                        }
                    }
                    winCheck = TKR.winCheck(game_board);
                }
                else if (winCheck == 1) 
                {
                    Console.Clear();
                    TKR.printBoard(game_board);
                    Console.WriteLine("X Wins!");
                    break;
                }
                else if (winCheck == 2)
                {
                    Console.Clear();
                    TKR.printBoard(game_board);
                    Console.WriteLine("O Wins!");
                    break;
                }
                else
                {
                    Console.Clear();
                    TKR.printBoard(game_board);
                    Console.WriteLine("It's a Draw!");
                    break;
                }
            }
        }
    }
}
