namespace Artefact.InventorySystem.ItemClasses
{ 
    public enum ItemType
    {
        Weapon,
        Armour,
        Key,
        Powerup,
        Crafting
    }

    public class Item
    {
        public int ID;
        public string name;
        public ItemType itemType;
        public int maximumStackableQuantity;
        public int quantity;
        
        protected Item()
        {
            quantity = 1;
            maximumStackableQuantity = 1;
        }

        public void AddToQuantity(int amountToAdd)
        {
            quantity += amountToAdd;

        }
    }
}