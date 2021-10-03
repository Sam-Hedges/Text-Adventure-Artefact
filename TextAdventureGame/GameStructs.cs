
namespace TextAdventureGame
{
    public struct Player
    {

    }

    public struct Inventory
    {

    }

    public struct Item
    {
        public Item(string name, int quantity, ItemType type)
        {
            Name = name;
            Quantity = quantity;
            ItemType = type;
        }

        public string Name;
        public int Quantity;
        public ItemType ItemType;
    }

    public struct ItemType
    {
        public ItemType(Weapon weapon)
        {
            Weapon = weapon;
        }

        public Weapon Weapon;
    }

    public struct Weapon
    {
        public Weapon(bool Weapon = false)
        {
            weapon = Weapon;
        }

        public bool weapon;
    }

    public struct Armour
    {

    }

    public struct  Key
    {

    }

    public struct Powerup
    {

    }

    public struct Story
    {

    }
}
