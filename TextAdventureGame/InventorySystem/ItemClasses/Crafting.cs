namespace Artefact.InventorySystem.ItemClasses
{
    public class Crafting : Item
    {
        public Crafting(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            SetMaxStackQuantity(20);
        }
        public Crafting(Crafting item) 
            : base(item)
        {
            SetMaxStackQuantity(20);
        }
    }
}
