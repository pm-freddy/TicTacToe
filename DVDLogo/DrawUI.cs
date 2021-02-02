using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DVDLogo
{
    class DrawUI
    {

        public List<string> DVDsign = new List<string>();

        public DrawUI()
        {
            //DVDsign.Add("..............   ....          ....  ..............  ");
            //DVDsign.Add("...............   ....        ....   ............... ");
            //DVDsign.Add("...         ....   ....      ....    ...         ....");
            //DVDsign.Add("...         ....    ....    ....     ...         ....");
            //DVDsign.Add("...         ....     ....  ....      ...         ....");
            //DVDsign.Add("...         ....      ........       ...         ....");
            //DVDsign.Add("...         ....       ......        ...         ....");
            //DVDsign.Add("...............         ....         ............... ");
            //DVDsign.Add("..............           ..          ..............  ");

            DVDsign.Add(@".---------------------------------.");
            DVDsign.Add(@"| |||||||\  \\       // |||||||\  |");
            DVDsign.Add(@"| ||     ||  \\     //  ||     || |");
            DVDsign.Add(@"| ||     ||   \\   //   ||     || |");
            DVDsign.Add(@"| ||     ||    \\ //    ||     || |");
            DVDsign.Add(@"| |||||||/      \//     |||||||/  |");
            DVDsign.Add(@"'---------------------------------'");
            DVDsign.Add(@"                                   ");






        }

       
      
        readonly ConsoleColor[] colorArray = new ConsoleColor[]{ConsoleColor.Red,
                                                            ConsoleColor.DarkGreen,
                                                            ConsoleColor.DarkCyan,
                                                            ConsoleColor.Magenta,
                                                            ConsoleColor.Magenta,
                                                            ConsoleColor.DarkYellow,
                                                            ConsoleColor.White};
        

        int saveValue = 0;
        bool height = true;
        bool width = true;
        int xAchse = 0;
        int yAchse = 0;
        bool DrawLogo = false;

        public void SwitchColor()
        {
            Random wuerfel = new Random();
            int randomZahl;
            do
            {
                randomZahl = wuerfel.Next(colorArray.Length);

            } while (randomZahl == saveValue);

            Console.ForegroundColor = colorArray[randomZahl];

            saveValue = randomZahl;
        }

        public void DrawSign()
        {
            for (int ListCounter = 0; ListCounter < DVDsign.Count - 1; ListCounter++)
            {
                if (DrawLogo)
                {
                    Console.SetCursorPosition(xAchse, yAchse + ListCounter);
                    Console.Write(DVDsign[ListCounter]);
                }
                else
                {
                    Console.SetCursorPosition(xAchse, yAchse + ListCounter);
                    Console.Write(DVDsign[^1]);


                }

            }
            DrawLogo = !DrawLogo;

        }
        public void CheckSign()
        {
            if (xAchse == (Console.WindowWidth - DVDsign[1].Length - 1))
            {
                SwitchColor();
                width = false;

            }
            if (xAchse == 0)
            {
                SwitchColor();
                width = true;

            }
            if (yAchse == (Console.WindowHeight - DVDsign.Count - 1))
            {
                SwitchColor();
                height = false;
            }
            if (yAchse == 0)
            {
                SwitchColor();
                height = true;
            }
            if (width) xAchse += 3;
            else xAchse -= 3;

            if (height) yAchse++;
            else yAchse--;
        }
    }
}
