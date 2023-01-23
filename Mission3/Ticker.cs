using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission3
{
    class Ticker
    {
        public void printBoard(int[] board)
        {
            string[] characters = new string[9];
            int position = 0;

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] > 0)
                {
                    if (board[i] == 1)
                    {
                        characters[i] = "o";
                    }
                    else
                    {
                        characters[i] = "x";
                    }
                }
                else
                {
                    position = (i + 1);
                    characters[i] = position.ToString();
                }
            }

            Console.WriteLine(" " + characters[0] + " | " + characters[1] + " | " + characters[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + characters[3] + " | " + characters[4] + " | " + characters[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + characters[6] + " | " + characters[7] + " | " + characters[8]);

        }

        public int winCheck(int[] board)
        {
            //return codes:
            //1: Player 1 wins (X)
            //2: Player 2 wins (O)
            //3: Tie
            //4: No winner, continue game

            bool empty = false;
            int score = 0;
            int[] vertical = { board[0], board[3], board[6], board[1], board[4], board[7], board[2], board[5], board[8] };

            //check for horizontal wins
            for (int i = 0; i < 3; i = i + 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[j] == 0)
                    {
                        empty = true;
                    }
                }
                if (empty == false)
                {
                    score = (board[i] + board[i + 1] + board[i + 2]);
                    if (score == 6)
                    {
                        return 1;
                    }
                    else if (score == 3)
                    {
                        return 2;
                    }
                }
                empty = false;
            }
            //check for vertical wins
            for (int i = 0; i < 3; i = i + 3)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (vertical[j] == 0)
                    {
                        empty = true;
                    }
                }
                if (empty == false)
                {
                    score = (vertical[i] + vertical[i + 1] + vertical[i + 2]);
                    if (score == 6)
                    {
                        return 1;
                    }
                    else if (score == 3)
                    {
                        return 2;
                    }
                }
                empty = false;
            }
            //check for diagonal wins
            if (board[0] == 0)
            {
                empty = true;
            }
            if (board[4] == 0)
            {
                empty = true;
            }
            if (board[8] == 0)
            {
                empty = true;
            }
            score = (board[0] + board[4] + board[8]);
            if (empty == false)
            {
                if (score == 6)
                {
                    return 1;
                }
                else if (score == 3)
                {
                    return 2;
                }
            }
            empty = false;
            //Left to right diagonal
            if (board[2] == 0)
            {
                empty = true;
            }
            if (board[4] == 0)
            {
                empty = true;
            }
            if (board[6] == 0)
            {
                empty = true;
            }
            score = (board[2] + board[4] + board[6]);
            if (empty == false)
            {
                if (score == 6)
                {
                    return 1;
                }
                else if (score == 3)
                {
                    return 2;
                }
            }
            empty = false;

            //check for a draw
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == 0)
                {
                    empty = true;
                }
            }
            if (empty == false)
            {
                return 3;
            }
            else
            {
                return 4;
            }

        }

    }
}
