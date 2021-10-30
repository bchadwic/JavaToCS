using System;
using System.Collections.Generic;
using System.Text;

namespace JavaToCS
{
    class Game
    {
        private Board board;
        private IO input;
        private Player player1;
        private Player player2;
        private Player current;
        private Player winner;
        private bool gameover;

        public Game()
        {
            input = new IO();
        }

        public void start()
        {
            init();
            loop();
        }

        void init()
        {
            player1 = new Player(input.getName(), input.getMarker());
            player2 = new Player(input.getName(), input.getMarker());
            board = new Board();
            current = player1;
            winner = null;
            gameover = false;
        }

        void loop()
        {
            while (!gameover) {
                while (true)
                {
                    int[] location;
                    do
                    {
                        input.printBoard(board);
                        location = input.getLocation(current);
                    } while (!isValidLocation(location));
                    board.setCell(current.getMarker(), location[0], location[1]);
                    if (gameOver())
                    {
                        gameover = true;
                        break;
                    }
                    current = current == player1 ? player2 : player1;
                }
                input.printBoard(board);
                Console.WriteLine(winner == null ? "It's a draw!" : $"{winner.getName()}, won!");  
                if (input.playAgain())
                {
                    init();
                } 
            }
        }

        bool isValidLocation(int[] location)
        {
            return board.getCell(location[0], location[1]) == ' ';
        }

        bool hasWon()
        {
            char[,] cboard = board.getBoard(); 

            // vertical check
            for (int i = 0; i < 3; i++)
            {
                if (cboard[0, i] == ' ')
                {
                    continue;
                }
                if (cboard[0, i] == cboard[1, i] && cboard[1, i] == cboard[2, i])
                {
                    winner = current;
                    return true;
                }
            }

            // horizontal
            for (int i = 0; i < 3; i++)
            {
                if (cboard[i, 0] == ' ')
                {
                    continue;
                }
                if (cboard[i, 0] == cboard[i, 1] && cboard[i, 1] == cboard[i, 2])
                {
                    winner = current;
                    return true;
                }
            }

            // diagonal
            char middle = cboard[1, 1];
            if (middle == ' ')
            {
                return false;
            }
            if(cboard[0,0] == middle && cboard[2,2] == middle)
            {
                winner = current;
                return true;
            }
            if(cboard[0,2] == middle && cboard[2,0] == middle)
            {
                winner = current;
                return true;
            }
            return false;
        }

        bool isFull()
        {
            char[,] cboard = board.getBoard(); 
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if(cboard[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        bool gameOver()
        {
            return isFull() || hasWon();
        }
    }
}

