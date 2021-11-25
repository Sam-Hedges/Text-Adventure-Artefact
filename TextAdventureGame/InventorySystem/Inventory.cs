using System;
using System.Collections.Generic;
using System.Linq;
using Artefact.Utilities;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.InventorySystem
{
    public class Inventory
    {
        private const int MaxInvSlots = 15;
        
        private readonly List<Item> _record = new List<Item>();
            
        public void AddItem(Item item, int iQuantityToAdd)
        {

            while (iQuantityToAdd > 0)
            {

                if (_record.Exists(x => (x.ID == item.ID) && (x.Quantity < item.MaxStackQuantity)))
                {
                    Item invRecord =
                    _record.First(x => (x.ID == item.ID) && (x.Quantity < item.MaxStackQuantity));

                    int maxStackQuantity = (item.MaxStackQuantity - invRecord.Quantity);

                    int quantityToAdd = Math.Min(iQuantityToAdd, maxStackQuantity);
                    
                    invRecord.AddToQuantity(quantityToAdd);

                    iQuantityToAdd -= quantityToAdd;
                }
                else
                {

                    if (_record.Count < MaxInvSlots)
                    {
                        Item tempItem;
                        
                        switch (item.ItemType)
                        {
                            case ItemType.Weapon:
                                tempItem = new Weapon((Weapon)item);
                                break;
                            case ItemType.Armour:
                                tempItem = new Armour((Armour)item);
                                break;
                            case ItemType.Key:
                                tempItem = new Key((Key)item);
                                break;
                            case ItemType.Powerup:
                                tempItem = new Powerup((Powerup)item);
                                break;
                            case ItemType.Crafting:
                                tempItem = new Crafting((Crafting)item);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                        
                        tempItem.SetQuantity(0);
                        
                        _record.Add(item);
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
                        Utils.WriteLineAdvanced($"\n{_record.Count} < {MaxInvSlots}");
                        foreach (Item items in _record)
                        {
                            Utils.WriteLineAdvanced($"\n{items.Name}");
                        }                      
                        Console.ReadLine();
                        throw new Exception("There is no more space in the inventory");
                    }

                }

            }

        }

        public Item ReturnItem(int index)
        {
            ItemType currentItemType = _record[index].ItemType;

            return _record[index];

        }
    }
}