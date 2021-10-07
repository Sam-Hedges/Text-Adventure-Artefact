using System;
using System.Collections.Generic;
using System.Linq;
using static System.Utils;
using Items;

namespace System
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
                        WriteLineCentered($"\n{record.Count} < {MAX_INV_SLOTS}");
                        for (int i = 0; i < record.Count; i++)
                        {
                            WriteLineCentered($"\n{record[i].name}");
                        }                      
                        Console.ReadLine();
                        throw new Exception("There is no more space in the inventory");
                    }

                }

            }

        }

    }
}