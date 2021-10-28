using Artefact.Utilities;
using System;

namespace Artefact
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
            Utils.WriteLineAdvanced(Prompt, true, false);

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string[] prefix = new string[] { " ", " " };

                if (i == SelectedIndex)
                {
                    prefix[0] = "---|>";
                    prefix[1] = "<|---";
                    Console.ForegroundColor = ConsoleColor.Green;
                    //BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix[0] = " ";
                    prefix[1] = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    //BackgroundColor = ConsoleColor.Black;
                }

                Utils.WriteLineAdvanced($"{prefix[0]} << {currentOption} >> {prefix[1]}", true, false);
            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
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
    }
}
