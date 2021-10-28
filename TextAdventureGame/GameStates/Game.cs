using System;
using System.IO;
using Artefact.Utilities;
using Items;

namespace Artefact
{
    class Game
    { 
        public void Start()
        {
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            string prompt = @"
                                                                                                                                                                              !    
    ███        ▄████████ ▀████    ▐████▀     ███             ▄████████ ████████▄   ▄█    █▄     ▄████████ ███▄▄▄▄       ███     ███    █▄     ▄████████    ▄████████         .-.   
▀█████████▄   ███    ███   ███▌   ████▀  ▀█████████▄        ███    ███ ███   ▀███ ███    ███   ███    ███ ███▀▀▀██▄ ▀█████████▄ ███    ███   ███    ███   ███    ███       __|=|__ 
   ▀███▀▀██   ███    █▀     ███  ▐███       ▀███▀▀██        ███    ███ ███    ███ ███    ███   ███    █▀  ███   ███    ▀███▀▀██ ███    ███   ███    ███   ███    █▀       (_/`-`\_)
    ███   ▀  ▄███▄▄▄        ▀███▄███▀        ███   ▀        ███    ███ ███    ███ ███    ███  ▄███▄▄▄     ███   ███     ███   ▀ ███    ███  ▄███▄▄▄▄██▀  ▄███▄▄▄          //\___/\\
    ███     ▀▀███▀▀▀        ████▀██▄         ███          ▀███████████ ███    ███ ███    ███ ▀▀███▀▀▀     ███   ███     ███     ███    ███ ▀▀███▀▀▀▀▀   ▀▀███▀▀▀          <>/   \<>
    ███       ███    █▄    ▐███  ▀███        ███            ███    ███ ███    ███ ███    ███   ███    █▄  ███   ███     ███     ███    ███ ▀███████████   ███    █▄        \|_._|/ 
    ███       ███    ███  ▄███     ███▄      ███            ███    ███ ███   ▄███ ███    ███   ███    ███ ███   ███     ███     ███    ███   ███    ███   ███    ███        <_I_>  
   ▄████▀     ██████████ ████       ███▄    ▄████▀          ███    █▀  ████████▀   ▀██████▀    ██████████  ▀█   █▀     ▄████▀   ████████▀    ███    ███   ██████████         |||   
                                                                                                                                             ███    ███                     /_|_\  

Use the Arrow keys & Enter key to navigate the menu

";
            string[] options = { "Play", "Settings", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    PlayGame();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    RunMainMenu();
                    break;
            }
        }

        private void ExitGame()
        {
            Console.Clear();
            Utils.WriteLineAdvanced("\nPress any key to exit...");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            Console.Clear();
            Utils.WriteLineAdvanced("\nAbout the game\nPress enter to return to the Main Menu");
            Console.ReadKey(true);
            RunMainMenu();
        }

        private void PlayGame()
        {         

            Console.Clear();
            Utils.WriteLineAdvanced($"\n{File.ReadAllText(Directories.ReturnDir(Scripts.Story))}");


            Console.ReadLine();
            RunMainMenu();
        }
    }
}
