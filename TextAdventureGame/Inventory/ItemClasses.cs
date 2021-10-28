namespace Items
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

    public class Weapon : Item
    {
        public Weapon()
        {
           
        }
        
        public float damage; 
        public float durability;
    }

    public class Armour : Item
    {
        public Armour()
        {

        }
    }

    public class Key : Item
    {
        public Key()
        {

        }
    }

    public class Powerup : Item
    {
        public Powerup()
        {
            maximumStackableQuantity = 10;
        }
    }

    public class Crafting : Item
    {
        public Crafting()
        {
            maximumStackableQuantity = 20;
        }
    }
}
