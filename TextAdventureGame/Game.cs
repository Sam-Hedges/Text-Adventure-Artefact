using System;
using System.IO;
using static System.Console;
using System.Runtime.InteropServices;
using static System.Utils;
using Items;

namespace TextAdventureGame
{
    class Game
    {

        /********************************************************************
         *  Title: Maximizing console window - C#
         *  Author: Châu .N
         *  Authored: 2 Jan. 2016
         *  Online: Stack Overflow
         *  Link: https://stackoverflow.com/questions/22053112/maximizing-console-window-c-sharp/22053200
         *  Accessed: 29 Sep. 2021
         ********************************************************************/

        #region Maximize Variables

        [DllImport("kernel32.dll", ExactSpelling = true)]                     
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr UtilsConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int MAXIMIZE = 3;

        #endregion

        public string[] directories;

        public void Start()
        {
            SetWindowSize(LargestWindowWidth, LargestWindowHeight); 
            ShowWindow(UtilsConsole, MAXIMIZE);

            Title = "Text Adventure - The Game";
            //SetWindowSize(LargestWindowWidth, LargestWindowHeight);
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
            Clear();
            WriteLineCentered("\nPress any key to exit...", true);
            ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            Clear();
            WriteLineCentered("\nAbout the game\nPress enter to return to the Main Menu", true);
            ReadKey(true);
            RunMainMenu();
        }

        private void PlayGame()
        {
            string[] searchFields = new string[] { "Story.txt", "Options.txt", "Fights.txt" };
            Dir getDirs = new Dir();
            directories = getDirs.Start(searchFields);

            Clear();
            WriteLineCentered($"\n{File.ReadAllText(directories[0])}", true);
            WriteLineCentered($"\n{RandNumbBetwRange(-10, 10, typeof(float))}", true);

            InventorySystem inventory = new InventorySystem();
            Weapon sword = new Weapon();
            sword.name = "Katana";
            sword.itemType = ItemType.Weapon;
            sword.ID = 0;
            sword.damage = 20f;
            sword.durability = 100f;

            inventory.AddItem(sword, 1);

            Weapon temp = (Weapon)inventory.record[0];
            if (temp.itemType == ItemType.Weapon)
            {
                WriteLineCentered($"\nName: {temp.name}", true);
                WriteLineCentered($"\nType: {temp.itemType}", true);
                WriteLineCentered($"\nID: {temp.ID}", true);
                WriteLineCentered($"\nQuantity: {temp.quantity}", true);
                WriteLineCentered($"\nDamage: {temp.damage}", true);
                WriteLineCentered($"\nDurability: {temp.durability}", true);
            }

            ReadLine();
            RunMainMenu();
        }
    }
}
