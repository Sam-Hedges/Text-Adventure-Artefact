using System;
using System.Collections.Generic;
using System.Linq;
using Artefact.Utilities;
using Artefact.InventorySystem.ItemClasses;

namespace Artefact.InventorySystem
{
    public class Inventory
    {

        public const int MAX_INV_SLOTS = 15;
        
        public readonly List<Item> record = new List<Item>();
            
        public void AddItem(Item item, int iQuantityToAdd)
        {

            while (iQuantityToAdd > 0)
            {

                if (record.Exists(x => (x.ID == item.ID) && (x.Quantity < item.MaxStackQuantity)))
                {
                    Item invRecord =
                    record.First(x => (x.ID == item.ID) && (x.Quantity < item.MaxStackQuantity));

                    int maxStackQuantity = (item.MaxStackQuantity - invRecord.Quantity);

                    int quantityToAdd = Math.Min(iQuantityToAdd, maxStackQuantity);
                    
                    invRecord.AddToQuantity(quantityToAdd);

                    iQuantityToAdd -= quantityToAdd;
                }
                else
                {

                    if (record.Count < MAX_INV_SLOTS)
                    {
                        switch(item.ItemType)
                        { 
                            
                        }

                        Item tempItem = new Item(item);
                        tempItem.SetQuantity(0);
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
                        Utils.WriteLineAdvanced($"\n{record.Count} < {MAX_INV_SLOTS}");
                        for (int i = 0; i < record.Count; i++)
                        {
                            Utils.WriteLineAdvanced($"\n{record[i].Name}");
                        }                      
                        Console.ReadLine();
                        throw new Exception("There is no more space in the inventory");
                    }

                }

            }

        }

        public Item ReturnItem(int index)
        {
            ItemType currentItemType = record[index].ItemType;

            return record[index];

        }
    }
}