using System;
using System.Runtime.Serialization;
using Artefact.EntitySystem;
using Artefact.InventorySystem.ItemClasses;
using Artefact.UI;
using Artefact.Utilities;

namespace Artefact.GameStates
{
    [DataContract]
    public static class GameManager
    {
        [DataMember]
        public static Entity Player;
        
        public static void InitializePlayer()
        {
            while (true)
            {
                Console.Clear();
                Utils.WriteLineAdvanced("Please enter your Name:");
                string name = Console.ReadLine();
                Console.Clear();

                Armour startArmour = new Armour(1, "Leather Armour", ItemType.Armour, 1, 10f, 1, "An old suit of leathery pelt held together with loose threads.", 5f, 10f);
                Weapon sword = new Weapon(1, "Steel Sword", ItemType.Weapon, 1, 15f, 1, "A rusty old cast steel blade.", 10f, 20f);
                Weapon axe = new Weapon(1, "Sturdy Axe", ItemType.Weapon, 1, 12f, 1, "A well worn logging axe.", 15f, 10f);
                Weapon bow = new Weapon(1, "Shortbow", ItemType.Weapon, 1, 10f, 1, "An oaken carved bow.", 7.5f, 30f);

                string[] options = {ReturnWeaponString(sword), ReturnWeaponString(axe), ReturnWeaponString(bow)};
                int index = Menu.Run("Choose your starting weapon:\n\n", options);

                Weapon weapon = new Weapon();
            
                switch (index)
                {
                    case 0:
                        weapon = new Weapon(sword);
                        break;
                    case 1:
                        weapon = new Weapon(axe);
                        break;
                    case 2:
                        weapon = new Weapon(bow);
                        break;
                }
            
                Player = new Entity(name, 100, weapon, startArmour);

                if (Menu.Run($"Are you happy with your choices?\nName: {Player.Name}\n{ReturnWeaponString(Player.EQ.Weapon)}", new[] {"Yes", "No"}) == 0)
                {
                    Console.Clear();
                    break;
                }
            }
        }

        private static string ReturnWeaponString(Weapon weapon)
        {
            return $"{weapon.Name}\nDamage: {weapon.Damage}\nDurability: {weapon.Durability}\n\n";
        }
    }
}