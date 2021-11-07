using System;
using System.Runtime.InteropServices;

namespace Artefact
{
    class Program
    {

        #region Maximize Variables

        /********************************************************************
        *  Title: Maximizing console window - C#
        *  Author: Châu .N
        *  Authored: 2 Jan. 2016
        *  Online: Stack Overflow
        *  Link: https://stackoverflow.com/questions/22053112/maximizing-console-window-c-sharp/22053200
        *  Accessed: 29 Sep. 2021
        ********************************************************************/

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr UtilsConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        #endregion

        static void Main(string[] args)
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(UtilsConsole, MAXIMIZE);

            Console.Title = "Text Adventure - The Game";

            Game newGame = new Game();
            newGame.Start();
        }
    }
}
