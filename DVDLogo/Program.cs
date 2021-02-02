using System;
using System.Collections.Generic;
using System.Threading;

namespace DVDLogo
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime date1 = DateTime.Now;
            DrawUI UI = new DrawUI();
            do
            {
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                Console.CursorVisible = false;
                if ((DateTime.Now - date1).TotalMilliseconds > 200)
                {
                    UI.DrawSign();
                    UI.CheckSign();
                    UI.DrawSign();
                    
                    date1 = DateTime.Now;
                }
            } while (!Console.KeyAvailable);
        }
    }
}
