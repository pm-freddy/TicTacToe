using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe.Scenes
{
    class StartScreen : Scene
    {
        public override void Update()
        {
            Console.SetCursorPosition(47, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Herzlich Willkommen zu");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("  .......... ... .........   ..........     .       .........   .......... ....... .........");
            Console.SetCursorPosition(15, 13);
            Console.WriteLine("  .......... . . .........   ..........    ...      .........   .......... ....... .........");
            Console.SetCursorPosition(15, 14);
            Console.WriteLine("     . .     . . ...            . .       .. ..     ...            . .     ..   .. ...      ");
            Console.SetCursorPosition(15, 15);
            Console.WriteLine("     . .     . . ...            . .      ..   ..    ...            . .     ..   .. .......  ");
            Console.SetCursorPosition(15, 16);
            Console.WriteLine("     . .     . . ...            . .     .........   ...            . .     ..   .. ...      ");
            Console.SetCursorPosition(15, 17);
            Console.WriteLine("     . .     . . .........      . .    ...     ...  .........      . .     ....... .........");
            Console.SetCursorPosition(15, 18);
            Console.WriteLine("     ...     ... .........      ...   ...       ... .........      ...     ....... .........");

            Thread.Sleep(5000);                         //Für alle kommenden Sleeps - wurde verwendet um ein gewisses Game-Feeling zu "simulieren
                                                        //Konsole arbeitet die Szenen zu schnell ab, da Größe des Spiels zu klein
                                                        //Auch mit PressedKeys oder anderen Dingen lösbar
            Console.ResetColor();
            Console.Clear();

            Program.Scenes.Pop();
            Program.Scenes.Push(new PlayerNames());

        }
    }
}
