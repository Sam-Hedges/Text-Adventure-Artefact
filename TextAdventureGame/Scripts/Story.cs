using System;
using System.Numerics;
using Artefact.GameStates;
using Artefact.UI;
using Artefact.Utilities;

namespace Artefact.Scripts
{
    public static class Story
    {
        public static void StoryProgress()
        {
            switch (GameManager.Player.Progress)
            {
                case 0:
                    Story1();
                    break;
                case 1:
                    Story2();
                    break;
                case 2:
                    Story3();
                    break;
                case 3:
                    Story4();
                    break;
                case 4:
                    Story5();
                    break;
                case 5:
                    Story6();
                    break;
                case 6:
                    Story7();
                    break;
                case 7:
                    Story8();
                    break;
                case 8:
                    Story9();
                    break;
                case 9:
                    Story10();
                    break;
            }
        }

        private static void Story1()
        {
            Utils.WriteLineAdvanced($@"You are {GameManager.Player.Name}, a brave adventurer of old. Famed for dangerous expeditions into the unknown.
It was one wintry night you feel restless and stumble upon an ancient cave ruins.

Press enter to continue");
            Console.ReadLine();
            Console.Clear();
            int index = Menu.Run("At the entrance the path diverges left and right.\n\n", new []{"Go Left\n", "Go Right\n"});

            switch (index)
            {
                case 0:
                    GameManager.Player.SetProgress(2);
                    break;
                case 1:
                    GameManager.Player.SetProgress(1);
                    break;
            }
            
            Console.Clear();
            StoryProgress();
        }
        
        private static void Story2()
        {
            Console.WriteLine("Right");
            Console.ReadLine();
        }
        
        private static void Story3()
        {
            Console.WriteLine("Left");
            Console.ReadLine();
        }
        
        private static void Story4()
        {
            
        }
        
        private static void Story5()
        {
            
        }
        
        private static void Story6()
        {
            
        }
        
        private static void Story7()
        {
            
        }
        
        private static void Story8()
        {
            
        }
        
        private static void Story9()
        {
            
        }
        
        private static void Story10()
        {
            
        }
    }
}