using System;
using System.Collections.Generic;
using System.Threading;
using TicTacToe.Scenes;

namespace TicTacToe
{


    class Program                                                   //TODO: Für alle Szenen komplette Trennung des UIs und der Spiellogik (benötigt komplette Überarbeitung der Szenen
                                                                    //siehe Kommentar - Klasse(Szene) Game.cs Zeile 10
    {
        public static Stack<Scene> Scenes = new();
        public static SaveData SaveData = new();                    // Da hier mit Szenen gearbeitet wird und jede Szene sich selbst wieder dekonstruiert, habe ich
                                                                    // eine Klasse eingebaut, welche szenenübergreifend wichtige Daten zwischenlagert und speichert.
                                                                    // TODO: andere Lösung finden, um die Daten nicht "unbedingt" static zu haben
        static void Main(string[] args)
        {
            Console.Title = "TicTacToe";
            Console.CursorVisible = false;


            Scenes.Push(new StartScreen());

            do
            {
                Scenes.Peek().Update();
            } while (Scenes.Count > 0);

        }
    }
}
