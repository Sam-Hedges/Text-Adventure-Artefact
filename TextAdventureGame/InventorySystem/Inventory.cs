using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Artefact.Utilities;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.InventorySystem
{
    [DataContract]
    public class Inventory
    {
        public Inventory() {}
        public Inventory(int maxInvSlots = 10, float balance = 0)
        {
            _maxInvSlots = maxInvSlots;
            _balance = balance;
        }
        
        [DataMember]
        private int _maxInvSlots;
        
        [DataMember]
        public float _balance;
        
        [DataMember]
        public List<Item> _record = new List<Item>();
            
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

                    if (_record.Count < _maxInvSlots)
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
                        Utils.WriteLineAdvanced($"\n{_record.Count} < {_maxInvSlots}");
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

        public void RemoveItem(Item item, int quantityToRemove)
        {
            while (quantityToRemove > 0)
            {

                if (_record.Exists(list => (list.Name == item.Name) && (list.Quantity >= 0)))
                {
                    Item currentItem = _record.First(list => (list.Name == item.Name) && (list.Quantity >= 0));

                    int tempQuantityToRemove = Math.Min(quantityToRemove, currentItem.Quantity);

                    currentItem.AddToQuantity(-tempQuantityToRemove);

                    quantityToRemove -= tempQuantityToRemove;

                    if (currentItem.Quantity < 1)
                    {
                        _record.Remove(currentItem);
                    }
                }
                else
                {
                    throw new Exception("Not valid item to remove or trying to remove too much");
                    //quantityToRemove = 0;
                }
 
            }
        }
    }
}