using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Scenes
{
    class PlayerNames : Scene
    {
        string UserInput;


        public override void Update()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(15, 12);
            Console.WriteLine("Bitte geben Sie die Spielernamen ein\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(15, 14);
            Console.Write("Spieler X: ");
            Console.ResetColor();
            UserInput = Console.ReadLine();
            Program.SaveData.PlayerNameX = UserInput ;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(15, 16);
            Console.Write("Spieler O: ");
            Console.ResetColor();
            UserInput = Console.ReadLine();
            Program.SaveData.PlayerNameO = UserInput;
            Console.CursorVisible = false;
            Console.Clear();
            Program.Scenes.Pop();
            Program.Scenes.Push(new Rules());
        }
    }
}
