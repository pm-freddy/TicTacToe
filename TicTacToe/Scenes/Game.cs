using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.Scenes
{
    class Game : Scene                                          //TODO: Spiellogik komplett von UI trennen (für alle Szenen)
    {
        Spielfeld spielfeld = new Spielfeld();
        UI DrawUserInterface = new UI();
        Point Lesekopf = new Point
        {
            X = 0,
            Y = 0
        };
        ConsoleKey pressedKey;
        bool systemShutdown = false;
        bool restSpielzüge = true;

        public override void Update()
        {
            do
            {
                spielfeld.PlayerNames[0] = Program.SaveData.PlayerNameX;
                spielfeld.PlayerNames[1] = Program.SaveData.PlayerNameO;
                Program.SaveData.Runde++;
                spielfeld.ResetBoard();
                Console.Clear();
                Thread.Sleep(500);                                                          
                DrawUserInterface.DrawTitle(spielfeld, Program.SaveData.Runde, Program.SaveData.SpielstandX, Program.SaveData.SpielstandO);
                DrawUserInterface.Draw(spielfeld.GetBoard);
                Console.WriteLine();

                do
                {
                    restSpielzüge = true;
                    Console.CursorVisible = false;

                    for (int counterColumn = 0; counterColumn < spielfeld.GetBoard.GetLength(0); counterColumn++)       // 
                    {                                                                                                   //  Navigation des Cursors über das Spielbrett
                        for (int counterRow = 0; counterRow < spielfeld.GetBoard.GetLength(1); counterRow++)            //
                    {
                            Console.SetCursorPosition((52 + counterColumn * 4), 12 + counterRow * 2);
                            Console.BackgroundColor = (counterColumn == Lesekopf.X && counterRow == Lesekopf.Y) ? ConsoleColor.White : ConsoleColor.Black;

                            switch (spielfeld.GetBoard[counterColumn, counterRow])
                            {
                                case FieldState.Empty:
                                    Console.WriteLine("-");
                                    break;
                                case FieldState.X:
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("X");
                                    break;
                                case FieldState.O:
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("O");
                                    break;
                                //case FieldState.Hint:                 TODO: Feature einbauen für einen Hinweis-Button, welcher Vorschläge für einen nächsten Zug gibt
                                //    break;
                                default:
                                    break;
                            }

                            Console.ResetColor();
                        }
                    }

                    pressedKey = Console.ReadKey(true).Key;

                    switch (pressedKey)
                    {
                        case ConsoleKey.Enter:
                            switch (spielfeld.Turn(Lesekopf))
                            {
                                case TurnResult.Valid:

                                    DrawUserInterface.DrawTitle(spielfeld, Program.SaveData.Runde , Program.SaveData.SpielstandX, Program.SaveData.SpielstandO);
                                    DrawUserInterface.Draw(spielfeld.GetBoard);
                                    break;

                                case TurnResult.Invalid:

                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(40, 21);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("Dieses Feld ist ungültig");
                                    Console.ResetColor();
                                    Thread.Sleep(1000);
                                    Console.SetCursorPosition(40, 21);
                                    Console.Write("                               ");    //Überschreiben der Meldung in Zeile 90
                                    Console.CursorVisible = true;
                                    break;

                                case TurnResult.Win:
                                    if (spielfeld.GetPlayerID)
                                    {
                                        Program.SaveData.SpielstandX++;
                                    }
                                    else
                                    {
                                        Program.SaveData.SpielstandO++;
                                    }

                                    DrawUserInterface.DrawTitle(spielfeld, Program.SaveData.Runde, Program.SaveData.SpielstandX, Program.SaveData.SpielstandO);
                                    DrawUserInterface.Draw(spielfeld.GetBoard);
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(25, 19);

                                    if (spielfeld.GetPlayerID)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write(spielfeld.PlayerNames[0]);
                                        Console.ResetColor();
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write(spielfeld.PlayerNames[1]);
                                        Console.ResetColor();
                                    }
                                    Console.Write(" hat gewonnen. Glückwunsch! :) Wollen Sie noch einmal spielen? [y/n]");

                                    ReInput:                                    
                                    pressedKey = Console.ReadKey(true).Key;
                                    if (pressedKey == ConsoleKey.Y)
                                    {
                                        restSpielzüge = false;
                                        break;
                                    }
                                    else if (pressedKey == ConsoleKey.N)
                                    {
                                        restSpielzüge = false;
                                        systemShutdown = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.SetCursorPosition(25, 21);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("Ungültige Eingabe");
                                        Console.ResetColor();
                                        Thread.Sleep(1000);
                                        Console.SetCursorPosition(25, 21);
                                        Console.Write("                          ");
                                        goto ReInput;               //Ausnahme goto...da vorerst nicht anders lösbar, goto für Funktionalität eingebaut (siehe auch Zeile 162)
                                    }

                                case TurnResult.Tie:

                                    DrawUserInterface.DrawTitle(spielfeld, Program.SaveData.Runde, Program.SaveData.SpielstandX, Program.SaveData.SpielstandO);
                                    DrawUserInterface.Draw(spielfeld.GetBoard);
                                    Console.CursorVisible = false;
                                    Console.SetCursorPosition(25, 19);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write("Unentschieden :) ");
                                    Console.ResetColor();
                                    Console.Write("Wollen Sie noch einmal spielen? [y/n]");
                                    goto ReInput;

                            }
                            break;

                        case ConsoleKey.LeftArrow:

                            if (Lesekopf.X > 0)
                            {
                                Lesekopf.X--;
                            }
                            break;

                        case ConsoleKey.UpArrow:

                            if (Lesekopf.Y > 0)
                            {
                                Lesekopf.Y--;
                            }
                            break;

                        case ConsoleKey.RightArrow:

                            if (Lesekopf.X < 2)
                            {
                                Lesekopf.X++;
                            }
                            break;

                        case ConsoleKey.DownArrow:

                            if (Lesekopf.Y < 2)
                            {
                                Lesekopf.Y++;
                            }
                            break;
                    }

                } while (restSpielzüge);
            } while (!systemShutdown);

            Program.Scenes.Pop();
            Program.Scenes.Push(new EndScreen());
        }
    }
}
