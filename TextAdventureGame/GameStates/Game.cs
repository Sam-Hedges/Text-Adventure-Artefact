using System;
using Artefact.UI;
using Artefact.Utilities;

namespace Artefact.GameStates
{
    public class Game
    { 
        public void Start()
        {
            RunMainMenu();
        }

        private void RunMainMenu()
        {
            #region MainMenuAscii

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

            #endregion
            string[] options = { "Play", "Settings", "Exit" };
            int selectedIndex = Menu.Run(prompt, options);

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
            GameManager.InitializePlayer();
            Console.Clear();
            Console.ReadLine();
            RunMainMenu();
        }
    }
}
