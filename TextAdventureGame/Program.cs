using System;
using static System.Console;

namespace TextAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game newGame = new Game();
            newGame.Start();
        }

        static void WriteRead(String a)
        {
            WriteLine(a);
            ReadLine();
            Clear();
        }
    }
}
