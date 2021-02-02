using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.Scenes
{
    class Rules : Scene
    {
        public override void Update()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("Regeln: ");
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("- Navigiere mit den Pfeiltasten durch das Spielfeld");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("- Bestätige mit <Enter> dein Feld");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("- Gewonnen hat die Person, welche als Erstes 3 Felder in einer Reihe hat");
            Console.SetCursorPosition(15, 16);
            Console.ResetColor();
            Console.WriteLine("Starte das Spiel mit <Enter>");

            for (; Console.ReadKey(true).Key != ConsoleKey.Enter;)
            {
                Console.SetCursorPosition(15, 20);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ungültige Eingabe");
                Thread.Sleep(1500);
                Console.SetCursorPosition(15, 20);
                Console.WriteLine("                                  ");
            }
            Console.ResetColor();
            Console.SetCursorPosition(15, 18);
            Console.Write("Spiel beginnt.");                    // Kleines von mir aus Spass eingebautes Gimmick um ein "Windows-Feeling" zu bekommen
            for (int counter = 0; counter < 4; counter++)       // Wer schätzt denn keine kleinen Ladezeiten ;)
            {                                                   // Hier auch die Möglichkeit über DateTime das Sleep zu ersetzen, um so den Thread
                Thread.Sleep(400);                              // nicht zu pausieren
                Console.Write(".");                             //
            }                                                   //
            Thread.Sleep(700);                                  //
            Console.Clear();

            Program.Scenes.Pop();
            Program.Scenes.Push(new Game());
        }
    }
}
