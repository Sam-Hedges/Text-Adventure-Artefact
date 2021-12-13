using System;
using Artefact.EntitySystem;
using Artefact.SaveSystem;
using Artefact.Scripts;
using Artefact.ScriptSettings;
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
            string[] options = { "Play", "Load Game", "Exit" };
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
            GameManager.Player = Save.LoadGame();
            Console.Clear();
            Utils.WriteLineAdvanced(GameManager.Player == null ? "Save File Empty" : "Save Loaded");

            Console.ReadKey(true);
            RunMainMenu();
        }

        private void PlayGame()
        {
            Console.Clear();
            GameManager.InitializePlayer();
            Story.StoryProgress();
            Console.Clear();
            Console.ReadLine();
            RunMainMenu();
        }
    }
}
