using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAdventureGame
{
    public class InventorySystem
    {
        private const int MAXIMUM_INV_SLOTS = 15;

        public readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();
            
        public void AddItem(ObtainableItem item, int quantityToAdd)
        {
            while (quantityToAdd > 0)
            {
                if (InventoryRecords.Exists(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity)))
                {
                    InventoryRecord inventoryRecord =
                    InventoryRecords.First(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity));

                    int maxQuantityYouCanAddToThisStack = (item.MaximumStackableQuantity - inventoryRecord.Quantity);

                    int quantityToAddToStack = Math.Min(quantityToAdd, maxQuantityYouCanAddToThisStack);
                    
                    inventoryRecord.AddToQuantity(quantityToAddToStack);

                    quantityToAdd -= quantityToAddToStack;
                }
                else
                {
                    if (InventoryRecords.Count < MAXIMUM_INV_SLOTS)
                    {
                        InventoryRecords.Add(new InventoryRecord(item, 0));
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
                        throw new Exception("There is no more space in the inventory");
                    }
                }
            }
        }

        public class InventoryRecord
        {
            public ObtainableItem InventoryItem { get; private set; }
            public int Quantity { get; private set; }

            public InventoryRecord(ObtainableItem item, int quantity)
            {
                InventoryItem = item;
                Quantity = quantity;
            }

            public void AddToQuantity(int amountToAdd)
            {
                Quantity += amountToAdd;
            }
        }
    }
}