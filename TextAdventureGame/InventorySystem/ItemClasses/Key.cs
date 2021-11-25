namespace Artefact.InventorySystem.ItemClasses
{
    public class Key : Item
    {
        public Key(int ID, string name, ItemType itemType, int quantity, float value, int maxStackQuantity, string description)
            : base(ID, name, itemType, quantity, value, maxStackQuantity, description)
        {
            SetMaxStackQuantity(1);
        }
        public Key(Key item) 
            : base(item)
        {
            SetMaxStackQuantity(1);
        }
    }
}
