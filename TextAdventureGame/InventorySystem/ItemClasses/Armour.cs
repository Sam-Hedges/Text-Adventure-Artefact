namespace Artefact.InventorySystem.ItemClasses
{
    public class Armour : Item
    {
        public Armour(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            SetMaxStackQuantity(1);
        }
        public Armour(Armour item) 
            : base(item)
        {
            SetMaxStackQuantity(1);
        }
    }
}
