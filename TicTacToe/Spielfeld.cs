using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    class Spielfeld
    {

        bool currentPlayerID;
        public string[] PlayerNames = new string[2];
        private readonly FieldState[,] _board = new FieldState[3, 3];
        private readonly Random _wuerfel = new Random();
        byte ZugNummer = 0;

        public bool GetPlayerID
        {
            get { return currentPlayerID; }
        }


        public FieldState[,] GetBoard
        {
            get { return _board; }
        }

        public Spielfeld()
        {
            ResetBoard();
        }

        public TurnResult Turn(Point Coordinates)
        {

            if (_board[Coordinates.X, Coordinates.Y] == FieldState.X || _board[Coordinates.X, Coordinates.Y] == FieldState.O)
            {
                return TurnResult.Invalid;
            }

            _board[Coordinates.X, Coordinates.Y] = (currentPlayerID ? FieldState.X : FieldState.O);
            ZugNummer++;
            currentPlayerID = !currentPlayerID;
            Thread.Sleep(300);

            if (
                (
                 (_board[0, 0] == _board[0, 1] && _board[0, 0] == _board[0, 2] && _board[0, 0] != FieldState.Empty) ||
                 (_board[1, 0] == _board[1, 1] && _board[1, 0] == _board[1, 2] && _board[1, 0] != FieldState.Empty) ||
                 (_board[2, 0] == _board[2, 1] && _board[2, 0] == _board[2, 2] && _board[2, 0] != FieldState.Empty) ||
                 (_board[0, 0] == _board[1, 0] && _board[0, 0] == _board[2, 0] && _board[0, 0] != FieldState.Empty) ||
                 (_board[0, 1] == _board[1, 1] && _board[0, 1] == _board[2, 1] && _board[0, 1] != FieldState.Empty) ||
                 (_board[0, 2] == _board[1, 2] && _board[0, 2] == _board[2, 2] && _board[0, 2] != FieldState.Empty) ||
                 (_board[0, 0] == _board[1, 1] && _board[0, 0] == _board[2, 2] && _board[0, 0] != FieldState.Empty) ||
                 (_board[0, 2] == _board[1, 1] && _board[0, 2] == _board[2, 0] && _board[0, 2] != FieldState.Empty)
                )
               )
            {
                currentPlayerID = !currentPlayerID;
                return TurnResult.Win;
            }
            else if (ZugNummer == 9)
            {
                return TurnResult.Tie;
            }
            else
                return TurnResult.Valid;

        }

        public void ResetBoard()
        {
            for (int xAchse = 0; xAchse < 3; xAchse++)
            {
                for (int yAchse = 0; yAchse < 3; yAchse++)
                {
                    _board[xAchse, yAchse] = FieldState.Empty;
                }
            }
            currentPlayerID = (_wuerfel.Next(10) % 2 == 0);
            ZugNummer = 0;
        }
                
    }
}
