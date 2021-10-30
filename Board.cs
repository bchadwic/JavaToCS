using System;
using System.Collections.Generic;
using System.Text;

namespace JavaToCS
{
    class Board
    {
        private char[,] board;

        public Board()
        {
            board = new char[,] 
            { 
                { ' ',' ',' ' }, 
                { ' ',' ',' ' }, 
                { ' ',' ',' ' } 
            };
        }

        public void setCell(char marker, int x, int y)
        {
            board[x, y] = marker;
        }

        public char getCell(int x, int y)
        {
            return board[x, y];
        }

        public char[,] getBoard()
        {
            return board;
        }
    }
}
