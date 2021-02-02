using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe.Scenes
{
    class EndScreen : Scene
    {
        public override void Update()
        {
            Console.Clear();
            Console.WriteLine(" ------------------------------------");
            Console.WriteLine("|   Endresultat nach " + Program.SaveData.Runde + (Program.SaveData.Runde > 1 ? " Runden:      |" : " Runde :      |"));
            Console.WriteLine(" ------------------------------------");
            Console.WriteLine("|                                   |");
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0,27} : ", Program.SaveData.PlayerNameX);
            Console.ResetColor();
            Console.WriteLine(Program.SaveData.SpielstandX + "    |");
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0,27} : ", Program.SaveData.PlayerNameO);
            Console.ResetColor();
            Console.WriteLine(Program.SaveData.SpielstandO + "    |");
            Console.WriteLine("|                                   |");
            Console.WriteLine(" ------------------------------------");
            Console.WriteLine("\n\n\nDrücke eine Taste um das Spiel zu beenden...");
            Console.ReadKey(true);
            Console.WriteLine("\n\n\nSpiel wird beendet . . .\n");
            Thread.Sleep(1500);
            Program.Scenes.Pop();
        }
    }
}
