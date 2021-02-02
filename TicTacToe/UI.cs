using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class UI
    {
        public void DrawTitle(Spielfeld obj, int round, int counterX, int counterO)
        {
            Console.SetCursorPosition(25, 8);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(obj.PlayerNames[0]);
            Console.ResetColor();
            Console.Write(" (X) : " + counterX + " | ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(obj.PlayerNames[1]);
            Console.ResetColor();
            Console.Write(" (O) : " + counterO + " || ");
            if (obj.GetPlayerID)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            Console.Write((obj.GetPlayerID ? obj.PlayerNames[0] : obj.PlayerNames[1]) + " ist am Zug.        ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(25, 10);
            Console.WriteLine("Runde " + round + ":");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void Draw(FieldState[,] Board)
        {
            for (int xAchse = 0; xAchse < 3; xAchse++)
            {
                for (int yAchse = 0; yAchse < 3; yAchse++)
                {
                    switch (Board[xAchse, yAchse])
                    {
                        case FieldState.Empty:
                            Console.SetCursorPosition(51 + xAchse * 4, 11 + yAchse * 2);
                            Console.Write("---");
                            Console.SetCursorPosition(50 + xAchse * 4, 12 + yAchse * 2);
                            Console.Write("|");
                            Console.SetCursorPosition(52 + xAchse * 4, 12 + yAchse * 2);
                            Console.Write("-");
                            Console.SetCursorPosition(62, 12 + yAchse * 2);
                            Console.Write("|");
                            Console.SetCursorPosition(51 + xAchse * 4, 17);
                            Console.Write("---");
                            break;
                        case FieldState.X:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(52 + xAchse * 4, 12 + yAchse * 2);
                            Console.Write("X");
                            Console.ResetColor();
                            break;
                        case FieldState.O:
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.SetCursorPosition(52 + xAchse * 4, 12 + yAchse * 2);
                            Console.Write("O");
                            Console.ResetColor();
                            break;
                        case FieldState.Hint:

                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
