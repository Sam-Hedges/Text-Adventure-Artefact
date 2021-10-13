using System;
using System.Collections.Generic;
using System.Linq;
using static System.Utils;
using Items;

namespace System.Inventory
{
    public class InventorySystem
    {

        public const int MAX_INV_SLOTS = 15;

        public readonly List<Item> record = new List<Item>();
            
        public void AddItem(Item item, int quantityToAdd)
        {

            while (quantityToAdd > 0)
            {

                if (record.Exists(x => (x.ID == item.ID) && (x.quantity < item.maximumStackableQuantity)))
                {
                    Item invRecord =
                    record.First(x => (x.ID == item.ID) && (x.quantity < item.maximumStackableQuantity));

                    int maxQuantityYouCanAddToThisStack = (item.maximumStackableQuantity - invRecord.quantity);

                    int quantityToAddToStack = Math.Min(quantityToAdd, maxQuantityYouCanAddToThisStack);
                    
                    invRecord.AddToQuantity(quantityToAddToStack);

                    quantityToAdd -= quantityToAddToStack;
                }
                else
                {

                    if (record.Count < MAX_INV_SLOTS)
                    {
                        Item tempItem = item;
                        tempItem.quantity = 0;
                        record.Add(item);
                    }
                    else
                    {
                        // WHEN NO SLOTS LEFT DISPLAY MESSAGE HERE
                        //
                        //
                        //
                        //
                        //
                        //***************************************
                        WriteLineAdvanced($"\n{record.Count} < {MAX_INV_SLOTS}");
                        for (int i = 0; i < record.Count; i++)
                        {
                            WriteLineAdvanced($"\n{record[i].name}");
                        }                      
                        Console.ReadLine();
                        throw new Exception("There is no more space in the inventory");
                    }

                }

            }

        }

        public dynamic ReturnItem(int index)
        {
            ItemType currentItemType = record[index].itemType;

            switch (currentItemType)
            {
                case ItemType.Weapon:
                    Weapon tempWeapon = (Weapon)record[index];
                    return tempWeapon;

                case ItemType.Armour:
                    Armour tempArmour = (Armour)record[index];
                    return tempArmour;

                case ItemType.Key:
                    Key tempKey = (Key)record[index];
                    return tempKey;

                case ItemType.Powerup:
                    Powerup tempPowerup = (Powerup)record[index];
                    return tempPowerup;

                case ItemType.Crafting:
                    Crafting tempCrafting = (Crafting)record[index];
                    return tempCrafting;

                default:
                    throw new Exception("Invalid Item Type");
            }

        }
    }
}