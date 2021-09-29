using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.String;

namespace TextAdventureGame
{
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            WriteLine(Prompt);
            //string dots = "...";
            //for (int i = 0; i < Prompt.Length; i++)
            //{
            //    Write(Prompt[i]);
            //    System.Threading.
            //        Thread.Sleep(1);
            //}

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string[] prefix = new string[] { " ", " " };

                if (i == SelectedIndex)
                {
                    prefix[0] = "---|>";
                    prefix[1] = "<|---";
                    ForegroundColor = ConsoleColor.Green;
                    //BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix[0] = " ";
                    prefix[1] = " ";
                    ForegroundColor = ConsoleColor.White;
                    //BackgroundColor = ConsoleColor.Black;
                }

                WriteLineCentered($"{prefix[0]} << {currentOption} >> {prefix[1]}");
            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {

                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                //Update SelectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectedIndex;
        }

        void WriteLineCentered(string textToEnter)
        {
            WriteLine(Format("{0," + ((WindowWidth / 2) + (textToEnter.Length / 2)) + "}", textToEnter));
        }
    }
}
