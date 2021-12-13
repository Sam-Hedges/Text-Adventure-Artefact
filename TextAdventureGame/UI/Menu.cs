using System;
using Artefact.Utilities;

namespace Artefact.UI
{
    public static class Menu
    {
        private static int _selectedIndex;
        private static string[] _options;
        private static string _prompt;

        private static void DisplayOptions(bool centerOption)
        {
            Utils.WriteLineAdvanced(_prompt, true, false);

            for (int i = 0; i < _options.Length; i++)
            {
                string currentOption = _options[i];

                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Utils.WriteLineAdvanced($"{currentOption}", centerOption, false);
            }
            Console.ResetColor();
        }
        public static int Run(string prompt, string[] options, bool centerOption = true)
        {
            _prompt = prompt;
            _options = options;
            _selectedIndex = 0;
            
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions(centerOption);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                //Update SelectedIndex based on arrow keys
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    _selectedIndex--;
                    if (_selectedIndex == -1)
                    {
                        _selectedIndex = _options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    _selectedIndex++;
                    if (_selectedIndex == _options.Length)
                    {
                        _selectedIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return _selectedIndex;
        }
    }
}
